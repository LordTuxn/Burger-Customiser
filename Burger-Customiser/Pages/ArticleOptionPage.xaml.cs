using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for Artikeloption.xaml
    /// </summary>
    public partial class ArticleOptionPage : Page {
        private readonly PageManager pageManager;

        public ArticleOptionPage(PageManager pageManager) {
            this.pageManager = pageManager;

            InitializeComponent();
        }

        private void BurgerLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.CatalogueType = 0;
            pageManager.NextPage();
        }

        private void CatalogueLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.CatalogueType = 1;
            pageManager.NextPage();
        }
    }
}
