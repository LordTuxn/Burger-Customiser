using Burger_Customiser.Navigation.Messages;
using Burger_Customiser_BLL;
using Burger_Customiser_DAL.Database;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using static Burger_Customiser.Navigation.Messages.ChangeCatalogueTypeMessage;

namespace Burger_Customiser.Navigation.Pages.Catalogue {
    public class CataloguePageVM : ViewModelBase, IPageViewModel {

        public List<Category> Categories { get; private set; }

        public List<Article> Articles { get; private set; }

        private string title;
        public string Title {
            get { return title; }
            set { Set(ref title, value); }
        }

        private string categoryName;
        public string CategoryName {
            get { return categoryName; }
            set { Set(ref categoryName, value); }
        }

        private CatalogueType catalogueType;
        public CatalogueType CatalogueType {
            get { return catalogueType; }
            set { catalogueType = value; }
        }

        public RelayCommand<string> SwitchCatalogueCategory { get; private set; }

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

        public void BackPage() {
            throw new NotImplementedException();
        }

        public void ContinuePage() {
            throw new NotImplementedException();
        }

        private void SwitchCategory(string categoryName) {
            CategoryName = categoryName;

            // TODO: Update articles
        }

        private void SetCatalogueType(ChangeCatalogueTypeMessage catalogueType) {
            CatalogueType = catalogueType.Type;
        }
    }
}
