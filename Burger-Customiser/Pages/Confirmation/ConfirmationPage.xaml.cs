using Burger_Customiser.Messages;
using Burger_Customiser.Pages.Start;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Pages.Confirmation {

    /// <summary>
    /// Interaction logic for ConfirmationPage.xaml
    /// </summary>
    public partial class ConfirmationPage : Page {

        public ConfirmationPage() {
            InitializeComponent();
        }

        private void ConfirmationPage_Click(object sender, MouseButtonEventArgs e) {
            Messenger.Default.Send(new ChangePageMessage(typeof(StartPageVM)));
        }
    }
}