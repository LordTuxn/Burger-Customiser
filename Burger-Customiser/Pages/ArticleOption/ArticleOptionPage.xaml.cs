using System.Windows.Controls;
using System.Windows.Input;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.Catalogue;
using GalaSoft.MvvmLight.Messaging;

namespace Burger_Customiser.Pages.ArticleOption {
    /// <summary>
    /// Interaction logic for ArticleOptionPage.xaml
    /// </summary>
    public partial class ArticleOptionPage : Page {
        public ArticleOptionPage() {
            InitializeComponent();
        }

        private void BurgerCustomiser_Click(object sender, MouseButtonEventArgs e) {
            // TODO: Set order option and send to next page

            Messenger.Default.Send(new ChangePageMessage(typeof(CataloguePageVM)));
        }

        private void ProductCatalogue_Click(object sender, MouseButtonEventArgs e) {
            // TODO: Set order option and send to next page

            Messenger.Default.Send(new ChangePageMessage(typeof(CataloguePageVM), CatalogueType.Product));
        }
    }
}
