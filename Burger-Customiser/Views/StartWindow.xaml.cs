using Burger_Customiser_BLL;
using Burger_Customiser_DAL.Database;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window {

        private readonly ILogger logger;

        private readonly ProductDAL products;

        public StartWindow(ILogger<StartWindow> logger, ProductDAL products) {
            this.logger = logger;

            this.products = products;
            InitializeComponent();
        }

        private void IdleScreenLMBDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            logger.LogInformation("Starting Window...");
            Main.Content = new Pages.Bestelloption(this);
            IdleScreen.Visibility = Visibility.Hidden;
            
            foreach(Category c in products.getCategories()) {
                //logger.LogInformation($"Product {p.ID}: {p.Name} ({p.Price})");
                logger.LogInformation($"Category {c.ID}: {c.Name}");
            }
        }
    }
}