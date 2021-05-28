using Burger_Customiser.Pages;
using Burger_Customiser_DAL.Database;
using System.Windows.Controls;

namespace Burger_Customiser {

    public enum MenuPages {
        StartSite, OrderOption, ArticleOption, BurgerCustomiser, ShoppingCart, Catalogue, Confirmation
    }

    public class PageManager {

        private readonly IngredientDAL ingredientDAL;

        public PageManager(StartWindow startWindow, IngredientDAL ingredientDAL) {
            StartWindow = startWindow;

            this.ingredientDAL = ingredientDAL;
        }

        public StartWindow StartWindow { get; set; } // TODO: Try to inject pages and create them using service provider

        public Page CurrentPage { get; private set; }

        public void Navigate(MenuPages page) {
            switch(page) {
                case MenuPages.StartSite:
                    CurrentPage = new StartSitePage(this);
                    break;
                case MenuPages.OrderOption:
                    CurrentPage = new OrderOptionPage(this);
                    break;
                case MenuPages.ArticleOption:
                    CurrentPage = new ArticleOptionPage(this);
                    break;
                case MenuPages.BurgerCustomiser:
                    CurrentPage = new BurgerCustomiserPage(this, ingredientDAL);
                    break;
                case MenuPages.Catalogue:

                    break;
                case MenuPages.ShoppingCart:

                    break;
                case MenuPages.Confirmation:

                    break;
            }

            StartWindow.Main.Navigate(CurrentPage);
        }
    }
}
