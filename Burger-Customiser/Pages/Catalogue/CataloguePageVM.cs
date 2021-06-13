using System;
using System.Collections.Generic;
using System.Windows;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser_BLL;
using Burger_Customiser_DAL.Database;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;
using static Burger_Customiser.Messages.ChangeCatalogueTypeMessage;

namespace Burger_Customiser.Pages.Catalogue {
    public class CataloguePageVM : PageViewModelBase {

        public List<Category> Categories { get; }

        public List<Article> Articles { get; }

        private string _title;
        public string Title {
            get => _title;
            set => Set(ref _title, value);
        }

        private string _categoryName;
        public string CategoryName {
            get => _categoryName;
            set => Set(ref _categoryName, value);
        }

        public CatalogueType CatalogueType { get; set; }

        public RelayCommand<string> SwitchCatalogueCategory { get; }

        [Obsolete("Only for design data!", true)]
        public CataloguePageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public CataloguePageVM(ILogger<CataloguePageVM> logger, CategoryDAL categoryDAL, ArticleDAL articleDAL) {
            logger.LogInformation($"Successfully Registered: {nameof(CataloguePageVM)}");

            SwitchCatalogueCategory = new RelayCommand<string>(SwitchCategory);

            // Register messenger for catalogue type (Burger Customiser / Products)
            Messenger.Default.Register<ChangeCatalogueTypeMessage>(this, SetCatalogueType);

            Categories = categoryDAL.GetCategoriesByType(0);
            Articles = CatalogueType == CatalogueType.Product ?
                articleDAL.GetProductsByCategory(4).ConvertAll(x => new Article { Name = x.Name, Price = x.Price, BackgroundImage = x.BackgroundImage }) :
                articleDAL.GetIngredientsByCategory(4).ConvertAll(x => new Article { Name = x.Name, Price = x.Price, BackgroundImage = x.BackgroundImage }); 
            // "Cast" the whole Product and Ingredient List to a universal Article List
            Title = "Burger Zusammenstellen";
            CategoryName = Categories[0].Name;
        }

        private void SwitchCategory(string categoryName) {
            CategoryName = categoryName;

            // TODO: Update articles
        }

        private void SetCatalogueType(ChangeCatalogueTypeMessage catalogueType) {
            CatalogueType = catalogueType.Type;
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
    }
}
