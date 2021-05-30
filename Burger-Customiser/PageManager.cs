using Burger_Customiser.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Burger_Customiser {

    public enum MenuPages {
        StartSite = 0, 
        OrderOption = 1, 
        ArticleOption = 2,
        BurgerCustomiser = 3,
        ProductCatalogue = 4,
        ShoppingCart = 5, 
        Confirmation = 6
    }

    public class PageManager {

        private readonly IHost serviceProvider;

        public PageManager(StartWindow startWindow, IHost serviceProvider) {
            StartWindow = startWindow;
            this.serviceProvider = serviceProvider;
        }

        public StartWindow StartWindow { get; set; }

        public MenuPages CurrentMenuPage { get; private set; }

        public int CatalogueType { get; set; }

        public void NextPage() {
            Navigate((MenuPages)(GetCurrentPageIndex() > Enum.GetValues(typeof(MenuPages)).Length ? 0 : GetCurrentPageIndex() + 1));
        }

        public void PreviousPage() {
            Navigate((MenuPages)(GetCurrentPageIndex() < 0 ? Enum.GetValues(typeof(MenuPages)).Length : GetCurrentPageIndex() - 1));
        }

        private int GetCurrentPageIndex() {
            return (int)Enum.Parse(typeof(MenuPages), CurrentMenuPage.ToString());
        }

        public void Navigate(MenuPages page) {
            Page currentPage;
            switch (page) {
                case MenuPages.StartSite:
                    currentPage = serviceProvider.Services.GetService<StartSitePage>();
                    break;
                case MenuPages.OrderOption:
                    currentPage = serviceProvider.Services.GetService<OrderOptionPage>();
                    break;
                case MenuPages.ArticleOption:
                    currentPage = serviceProvider.Services.GetService<ArticleOptionPage>();
                    break;
                default:
                    currentPage = serviceProvider.Services.GetService<Catalogue>();
                    break;
            }

            CurrentMenuPage = (MenuPages)Enum.Parse(typeof(MenuPages), currentPage.Title, true);
            StartWindow.Main.Navigate(currentPage);
        }
    }
}
