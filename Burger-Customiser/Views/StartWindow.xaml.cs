using Burger_Customiser.Pages;
using Burger_Customiser.UserControls;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window {

        private readonly IHost host;

        public StartWindow(ILogger<StartWindow> logger, IHost host) {
            logger.LogInformation("Starting Application...");
            this.host = host;
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e) {
            //Add Navigation Footer
            MainGrid.Children.Add(new NavigationFooter(host.Services.GetService<PageManager>()));
        }
    }
}