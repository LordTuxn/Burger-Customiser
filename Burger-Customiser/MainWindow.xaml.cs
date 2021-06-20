using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ShoppingCart;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow(ILogger<MainWindow> logger, MainWindowVM mainWindowVM) {
            logger.LogInformation("Starting Application...");
            InitializeComponent();

            DataContext = mainWindowVM;
        }

        private void ShoppingCart_Click(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Messenger.Default.Send(new ChangePageMessage(typeof(ShoppingCartPageVM)));
        }
    }
}