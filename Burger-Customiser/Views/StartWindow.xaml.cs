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

        private readonly IngredientDAL ingredientDAL;

        public StartWindow(ILogger<StartWindow> logger, IngredientDAL ingredientDAL) {
            this.logger = logger;

            this.ingredientDAL = ingredientDAL;
            InitializeComponent();
        }

        private void IdleScreenLMBDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            logger.LogInformation("Starting Window...");
            Main.Content = new Pages.Bestelloption(ingredientDAL, this);
            IdleScreen.Visibility = Visibility.Hidden;
            
            foreach(Ingredient i in ingredientDAL.GetIngredients()) {
                logger.LogInformation($"Category {i.Name}: {i.ID}");
                i.BackgroundImage = "Test";
                ingredientDAL.UpdateIngredient(i);
            }

           
        }
    }
}