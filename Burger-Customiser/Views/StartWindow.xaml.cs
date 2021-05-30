using Burger_Customiser.Pages;
using Burger_Customiser.UserControls;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Input;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window {

        public StartWindow(ILogger<StartWindow> logger) {
            //logger.LogInformation("Starting Application...");

            InitializeComponent();

            //Add Navigation Footer
            //MainGrid.Children.Add(new NavigationFooter(new PageManager(this, host)));
        }
    }
}