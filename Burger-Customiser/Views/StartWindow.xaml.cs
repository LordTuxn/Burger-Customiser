using Burger_Customiser.Pages;
using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Input;

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

        private void IdleScreenLMBDown(object sender, MouseButtonEventArgs e) {
            logger.LogInformation("Starting Window...");
            Main.Content = new Bestelloption(new PageManager(this));
            IdleScreen.Visibility = Visibility.Hidden;
        }
    }
}