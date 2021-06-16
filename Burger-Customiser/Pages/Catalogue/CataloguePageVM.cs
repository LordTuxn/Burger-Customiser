using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser_BLL;
using Burger_Customiser_DAL.Database;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.Catalogue {
    public class CataloguePageVM : PageViewModelBase, INotifyPropertyChanged {
        private readonly ILogger<CataloguePageVM> _logger;
        private readonly CategoryDAL _categoryDAL;
        private readonly ArticleDAL _articleDal;

        public new event PropertyChangedEventHandler PropertyChanged;

        public List<Category> Categories { get; private set; }

        public List<ArticleItem> ArticleItems { get; private set; }

        public Dictionary<Article, int> ShoppingCart = new Dictionary<Article, int>();

        private string _pageTitle;
        public string PageTitle {
            get => _pageTitle;
            set {
                Set(ref _pageTitle, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PageTitle"));
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

        public CatalogueType CatalogueType { get; set; }

        public RelayCommand<string> SwitchCatalogueCategory { get; }
        public RelayCommand<string> AddArticleToShoppingCart { get; }
        public RelayCommand<string> RemoveArticleFromShoppingCart { get; }

        [Obsolete("Only for design data!", true)]
        public CataloguePageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public CataloguePageVM(ILogger<CataloguePageVM> logger, CategoryDAL categoryDAL, ArticleDAL articleDAL) {
            _logger = logger;
            _categoryDAL = categoryDAL;
            _articleDal = articleDAL;

            logger.LogInformation($"Successfully Registered: {nameof(CataloguePageVM)}");

            SwitchCatalogueCategory = new RelayCommand<string>(SwitchCategory);

            AddArticleToShoppingCart = new RelayCommand<string>(Add_ArticleToShoppingCart);
            RemoveArticleFromShoppingCart = new RelayCommand<string>(Remove_ArticleFromShoppingCart);

            // "Cast" the whole Product and Ingredient List to a universal Article List
            PageTitle = CatalogueType == CatalogueType.Product ?
                "PRODUKT KATALOG" : "BURGER ZUSAMMENSTELLEN";
            
            UpdateCategories();
            CategoryName = Categories[0].Name;

            UpdateArticles(Categories[0].ID);
        }

        private void SwitchCategory(string categoryName) {
            CategoryName = categoryName;

            UpdateArticles(Categories.Find(c => c.Name == categoryName).ID);
        }

        public override NavigationButton GetBackButton() {
            return new NavigationButton("ZURÜCK", onClick => {
                Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
            });
        }

        public override NavigationButton GetContinueButton() {
            return new NavigationButton("HINZUFÜGEN", onClick => {
                // TODO: Add to shopping cart

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
            Categories = _categoryDAL.GetCategoriesByType(CatalogueType == CatalogueType.Product ? 1 : 0);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Categories"));
        }

        private void UpdateArticles(int categoryId) {
            _logger.LogInformation("CategoryType: " + CatalogueType);
            var articles = CatalogueType == CatalogueType.Product ?
                _articleDal.GetProductsByCategory(categoryId).ConvertAll(x => new Article { Name = x.Name, Price = x.Price, BackgroundImage = x.BackgroundImage }) :
                _articleDal.GetIngredientsByCategory(categoryId).ConvertAll(x => new Article { Name = x.Name, Price = x.Price, BackgroundImage = x.BackgroundImage });

            ArticleItems = articles.Select(article => new ArticleItem(article)).ToList();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ArticleItems"));
        }
    }
}
