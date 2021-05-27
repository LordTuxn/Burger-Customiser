using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for Bestelloption.xaml
    /// </summary>
    public partial class OrderOptionPage : Page, IDisposable {

        private readonly PageManager pageManager;

        public OrderOptionPage(PageManager pageManager) {
            this.pageManager = pageManager;

            InitializeComponent();
        }

        private void EatHereLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.Navigate(MenuPages.ArticleOption);
        }

        private void TakeawayLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.Navigate(MenuPages.ArticleOption);
        }

        public void Dispose() {
            this.Dispose();
        }
    }
}
