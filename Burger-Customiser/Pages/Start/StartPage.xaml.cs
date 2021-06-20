using Burger_Customiser.Messages;
using Burger_Customiser.Pages.OrderOption;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace Burger_Customiser.Pages.Start {

    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page {

        public StartPage() {
            InitializeComponent();
        }

        private void StartPage_Click(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Messenger.Default.Send(new ChangePageMessage(typeof(OrderOptionPageVM)));
        }
    }
}