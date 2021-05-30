using Burger_Customiser.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Controls;

namespace Burger_Customiser {

    public enum MenuPages {
        StartSite = 0, 
        OrderOption = 1, 
        ArticleOption = 2, 
        Catalogue = 3,
        ShoppingCart = 4, 
        Confirmation = 5
    }

    public class PageManager {

        private readonly IHost serviceProvider;

        public PageManager(StartWindow startWindow, IHost serviceProvider) {
            StartWindow = startWindow;
            this.serviceProvider = serviceProvider;
        }

        public StartWindow StartWindow { get; set; }

        public Page CurrentPage { get; private set; }

        public void NextPage() {
            Navigate((MenuPages)(GetCurrentPageIndex() > Enum.GetValues(typeof(MenuPages)).Length ? 0 : GetCurrentPageIndex() + 1));
        }

        public void PreviousPage() {
            Navigate((MenuPages)(GetCurrentPageIndex() < 0 ? Enum.GetValues(typeof(MenuPages)).Length : GetCurrentPageIndex() - 1));
        }

        private int GetCurrentPageIndex() {
            if (CurrentPage.Title == "Catalogue")
            {
                Catalogue catalogue = (Catalogue)CurrentPage;
                switch ((int) catalogue.Type)
                {
                    case 0:
                        return (int)Enum.Parse(typeof(MenuPages), "BurgerCustomiser");
                    case 1:
                        return (int)Enum.Parse(typeof(MenuPages), "Catalogue");
                }
            }
            return (int)Enum.Parse(typeof(MenuPages), CurrentPage.Title);
        }

        public void Navigate(MenuPages page) {
            switch (page) {
                case MenuPages.StartSite:
                    CurrentPage = serviceProvider.Services.GetService<StartSitePage>();
                    break;
                case MenuPages.OrderOption:
                    CurrentPage = serviceProvider.Services.GetService<OrderOptionPage>();
                    break;
                case MenuPages.ArticleOption:
                    CurrentPage = serviceProvider.Services.GetService<ArticleOptionPage>();
                    break;
                case MenuPages.Catalogue:
                    // Do stuff
                    CurrentPage = serviceProvider.Services.GetService<Catalogue>();
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
