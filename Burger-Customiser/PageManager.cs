using Burger_Customiser.Pages;
using System.Windows.Controls;

namespace Burger_Customiser {

    public enum MenuPages {
        Artikeloption, Bestelloption, BurgerCustomiser
    }

    public class PageManager {

        private readonly StartWindow startWindow;

        public PageManager(StartWindow startWindow) {
            this.startWindow = startWindow;
        }

        public Page CurrentPage { get; private set; }

        public void Navigate(MenuPages page) {
            switch(page) {
                case MenuPages.Bestelloption:
                    CurrentPage = new Bestelloption(this);
                    break;
                case MenuPages.Artikeloption:
                    CurrentPage = new Artikeloption(this);
                    break;
                case MenuPages.BurgerCustomiser:
                    CurrentPage = new BurgerCustomiser(this);
                    break;
            }
            startWindow.Main.Content = CurrentPage;
        }
    }
}
