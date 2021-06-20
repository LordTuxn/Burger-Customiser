using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser_BLL;
using Burger_Customiser_DAL;
using Burger_Customiser_DAL.Database;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Burger_Customiser_BLL.Relationships;

namespace Burger_Customiser.Pages.Catalogue {

    public class CataloguePageVM : PageViewModelBase, INotifyPropertyChanged {
        public CatalogueType CatalogueType { get; set; }

        public List<Category> Categories { get; private set; }

        public List<ArticleItem> ArticleItems { get; private set; }

        public Dictionary<Article, int> ShoppingCart = new Dictionary<Article, int>();

        private string _catalogueTypeTitle;

        public string CatalogueTypeTitle {
            get => _catalogueTypeTitle;
            set {
                Set(ref _catalogueTypeTitle, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CatalogueTypeTitle"));
            }
        }

        private string _categoryName;

        public string CategoryName {
            get => _categoryName;
            set {
                Set(ref _categoryName, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CategoryName"));
            }
        }

        private readonly CategoryDAL _categoryDAL;
        private readonly ArticleDAL _articleDAL;
        private readonly BurgerDAL _burgerDAL;
        private readonly OrderManager _orderManager;

        public new event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand<int> SwitchCatalogueCategory { get; }
        public RelayCommand<string> AddArticleToShoppingCart { get; }
        public RelayCommand<string> RemoveArticleFromShoppingCart { get; }

        [Obsolete("Only for design data!", true)]
        public CataloguePageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public CataloguePageVM(ILogger<CataloguePageVM> logger, CategoryDAL categoryDAL, ArticleDAL articleDAL, OrderManager orderManager) {
            _categoryDAL = categoryDAL;
            _articleDAL = articleDAL;
            _orderManager = orderManager;

            SwitchCatalogueCategory = new RelayCommand<int>(SwitchCategory);

            AddArticleToShoppingCart = new RelayCommand<string>(Add_ArticleToShoppingCart);
            RemoveArticleFromShoppingCart = new RelayCommand<string>(Remove_ArticleFromShoppingCart);

            // Register messenger for changing catalogue type
            Messenger.Default.Register<ChangeCatalogueTypeMessage>(this, SwitchCatalogueType);

            logger.LogInformation($"Successfully Registered: {nameof(CataloguePageVM)}");
        }

        private void SwitchCatalogueType(ChangeCatalogueTypeMessage type) {
            ShoppingCart.Clear();
            CatalogueType = type.CatalogueType;

            CatalogueTypeTitle = CatalogueType == CatalogueType.Product ?
                "PRODUKT KATALOG" : "BURGER ZUSAMMENSTELLEN";

            UpdateCategories();
            if (Categories.Count > 0) SwitchCategory(Categories[0].ID);
        }

        private void SwitchCategory(int categoryId) {
            string newCategoryName;
            try {
                newCategoryName = _categoryDAL.GetCategoryById(categoryId).Name;
            } catch (ConnectionFailedException) {
                return;
            }

            if (CategoryName == newCategoryName) return;
            CategoryName = newCategoryName;

            UpdateArticles(categoryId);
        }

        public override NavigationButton GetBackButton() {
            return new NavigationButton("ZURÜCK", onClick => {
                Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
            });
        }

        public override NavigationButton GetContinueButton() {
            return new NavigationButton("HINZUFÜGEN", onClick => {
                if (CatalogueType == CatalogueType.Ingredient) {
                    Burger burger = new Burger();
                    List<BurgerIngredient> burgerIngredients = new List<BurgerIngredient>();

                    foreach (Article article in ShoppingCart.Keys) {
                        burgerIngredients.Add(new BurgerIngredient {
                            Amount = ShoppingCart[article],
                            BurgerID = burger.ID,
                            CategoryID = article.CategoryID,
                            IngredientID = article.ID
                        });
                    }

                    burger.BurgerIngredients = burgerIngredients;
                    _orderManager.AddBurger(burger, 1);
                } else {
                    foreach (Article article in ShoppingCart.Keys) {
                        _orderManager.AddProduct(new Product {
                            CategoryID = article.CategoryID,
                            ID = article.ID,
                            InStock = article.InStock,
                            Name = article.Name,
                            Price = article.Price
                        }, ShoppingCart[article]);
                    }
                }

                Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
            }, Application.Current.FindResource("ShoppingCartButton") as Style);
        }

        private void Add_ArticleToShoppingCart(string articleName) {
            var item = GetItemByArticle(articleName);
            if (!item.AddArticle()) return;

            if (!ShoppingCart.ContainsKey(item.Article)) {
                ShoppingCart.Add(item.Article, 1);
            } else {
                ShoppingCart[item.Article] = item.Amount;
            }
        }

        private void Remove_ArticleFromShoppingCart(string articleName) {
            var item = GetItemByArticle(articleName);
            if (!item.RemoveArticle()) return;

            if (ShoppingCart.ContainsKey(item.Article) && item.Amount == 0) {
                ShoppingCart.Remove(item.Article);
            } else {
                ShoppingCart[item.Article] = item.Amount;
            }
        }

        private ArticleItem GetItemByArticle(string articleName) {
            return ArticleItems.Find(arIt => arIt.Article.Name == articleName);
        }

        private void UpdateCategories() {
            try {
                Categories = _categoryDAL.GetCategoriesByType(CatalogueType == CatalogueType.Product ? 1 : 0);
            } catch (ConnectionFailedException) {
                Categories = new List<Category>();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Categories"));
        }

        private void UpdateArticles(int categoryId) {
            try {
                List<Article> articles = CatalogueType == CatalogueType.Product ?
                    _articleDAL.GetProductsByCategory(categoryId).ConvertAll(x => new Article { Name = x.Name, Price = x.Price, BackgroundImage = x.BackgroundImage }) :
                    _articleDAL.GetIngredientsByCategory(categoryId).ConvertAll(x => new Article { Name = x.Name, Price = x.Price, BackgroundImage = x.BackgroundImage });

                // Convert articles to articleItem and set amount in Shopping Cart
                List<ArticleItem> items = new List<ArticleItem>();
                foreach (Article article in articles) {
                    ArticleItem articleItem = new ArticleItem(article);

                    if (ShoppingCart.Keys.Any(shopItem => shopItem.Name == article.Name)) {
                        articleItem.Amount = ShoppingCart.FirstOrDefault(item => item.Key.Name == article.Name).Value;
                    }

                    items.Add(articleItem);
                }

                ArticleItems = items;
            } catch (ConnectionFailedException) {
                ArticleItems = new List<ArticleItem>();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ArticleItems"));
        }
    }
}