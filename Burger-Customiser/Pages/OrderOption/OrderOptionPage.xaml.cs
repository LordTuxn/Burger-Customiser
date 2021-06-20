using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Pages.OrderOption {

    /// <summary>
    /// Interaction logic for OrderPageView.xaml
    /// </summary>
    public partial class OrderOptionPage : Page {

        public OrderOptionPage() {
            InitializeComponent();
        }

        private void EatHere_Click(object sender, MouseButtonEventArgs e) {
            Messenger.Default.Send(new ChangeToTakeAwayOptionMessage(false));
            Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
        }

        private void Takeaway_Click(object sender, MouseButtonEventArgs e) {
            Messenger.Default.Send(new ChangeToTakeAwayOptionMessage(true));
            Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
        }
    }
}