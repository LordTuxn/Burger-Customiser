using Burger_Customiser.Navigation.Messages;
using Burger_Customiser.Navigation.Pages.Catalogue;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Burger_Customiser.Navigation.Messages.ChangeCatalogueTypeMessage;

namespace Burger_Customiser.Navigation.Pages.ArticleOption {
    /// <summary>
    /// Interaction logic for ArticleOptionPage.xaml
    /// </summary>
    public partial class ArticleOptionPage : Page {
        public ArticleOptionPage() {
            InitializeComponent();
        }

        private void BurgerCustomiser_Click(object sender, MouseButtonEventArgs e) {
            // TODO: Set order option and send to next page

            Messenger.Default.Send(new ChangeCatalogueTypeMessage(CatalogueType.Ingredient));
            Messenger.Default.Send(new ChangePageMessage(typeof(CataloguePageVM)));
        }

        private void ProductCatalogue_Click(object sender, MouseButtonEventArgs e) {
            // TODO: Set order option and send to next page

            Messenger.Default.Send(new ChangeCatalogueTypeMessage(CatalogueType.Product));
            Messenger.Default.Send(new ChangePageMessage(typeof(CataloguePageVM)));
        }
    }
}
