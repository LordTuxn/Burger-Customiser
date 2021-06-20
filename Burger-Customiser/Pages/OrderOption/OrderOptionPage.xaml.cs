using System.Windows.Controls;
using System.Windows.Input;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using GalaSoft.MvvmLight.Messaging;

namespace Burger_Customiser.Pages.OrderOption {

    /// <summary>
    /// Interaction logic for OrderPageView.xaml
    /// </summary>
    public partial class OrderOptionPage : Page {

        public OrderOptionPage() {
            InitializeComponent();
        }

        private void EatHere_Click(object sender, MouseButtonEventArgs e) {

            Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
        }

        private void Takeaway_Click(object sender, MouseButtonEventArgs e) {
            // TODO: Set order option

            Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
        }
    }
}