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
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.Start;
using GalaSoft.MvvmLight.Messaging;

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
