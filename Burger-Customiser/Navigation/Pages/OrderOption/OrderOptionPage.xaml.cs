using Burger_Customiser.Navigation.Messages;
using Burger_Customiser.Navigation.Pages.ArticleOption;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Navigation.Pages.OrderOption {

    /// <summary>
    /// Interaction logic for OrderPageView.xaml
    /// </summary>
    public partial class OrderOptionPage : Page {

        public OrderOptionPage() {
            InitializeComponent();
        }

        private void EatHere_Click(object sender, MouseButtonEventArgs e) {
            // TODO: Set order option

            Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
        }

        private void Takeaway_Click(object sender, MouseButtonEventArgs e) {
            // TODO: Set order option

            Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
        }
    }
}