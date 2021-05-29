using Burger_Customiser.UserControls;
using Burger_Customiser_DAL.Database;
using System;
using System.Windows.Controls;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for BurgerCustomiser.xaml
    /// </summary>
    public partial class BurgerCustomiserPage : Page { // Add IDisposable interface to fix memory leaks

        private readonly PageManager pageManager;
        private readonly IngredientDAL ingredientDAL;

        public BurgerCustomiserPage(PageManager pageManager, IngredientDAL ingredientDAL, CategoryDAL categoryDAL) { //lmao xd ich hass dependency injections xDDDD :kms:
            this.pageManager = pageManager;
            this.ingredientDAL = ingredientDAL;

            InitializeComponent();

            // Add ItemList
            // Set default category, that the user will see first
            ProductList productList = new ProductList(ingredientDAL, ingredientDAL.GetCategories()[0]);
            categoryName.Text = ingredientDAL.GetCategories()[0].Name;
            MainGrid.Children.Add(productList);
            // Add Navigator
            MainGrid.Children.Add(new Navigator(categoryDAL, ingredientDAL, productList, categoryName));
        }

        public void Dispose() {
            this.Dispose();
        }
    }
}
