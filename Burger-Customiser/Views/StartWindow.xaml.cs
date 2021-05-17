using Microsoft.Extensions.Logging;
using System.Windows;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window {

        private readonly ILogger logger;

        public StartWindow(ILogger<StartWindow> logger) {
            this.logger = logger;
            InitializeComponent();
        }

        private void IdleScreenLMBDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            logger.LogInformation("Starting Window...");
            Main.Content = new Pages.Bestelloption();
            IdleScreen.Visibility = Visibility.Hidden;
        }
    }
}