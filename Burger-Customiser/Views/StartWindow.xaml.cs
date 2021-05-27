using Burger_Customiser.Pages;
using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Input;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window {

        public StartWindow(ILogger<StartWindow> logger) {
            logger.LogInformation("Starting Application...");
            InitializeComponent();
        }
    }
}