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
    }
}