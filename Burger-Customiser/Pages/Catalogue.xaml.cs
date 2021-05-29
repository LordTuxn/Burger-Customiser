using Burger_Customiser.UserControls;
using Burger_Customiser_DAL.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Burger_Customiser.Pages
{
    /// <summary>
    /// Interaction logic for Catalogue.xaml
    /// </summary>
    public partial class Catalogue : Page { // Add IDisposable interface to fix memory leaks

        private readonly PageManager pageManager;
        private readonly IngredientDAL ingredientDAL;
        private readonly ProductDAL productDAL;

        // Again... haben immer noch keine Vererbung...
        public Catalogue(PageManager pm, IngredientDAL ingredientDAL, CategoryDAL categoryDAL) : this(pm, ingredientDAL, null, categoryDAL) {
            title.Text = "Burger Customiser";
            Type = 0;
        }
        public Catalogue(PageManager pm, ProductDAL productDAL, CategoryDAL categoryDAL) : this(pm, null, productDAL, categoryDAL) {
            title.Text = "Product Catalogue";
            Type = 1;
        }

        public Catalogue(PageManager pm, IngredientDAL ingredientDAL, ProductDAL productDAL, CategoryDAL categoryDAL)
        {
            this.pageManager = pm;
            this.ingredientDAL = ingredientDAL;
            this.productDAL = productDAL;

            InitializeComponent();

            // Add ItemList
            // Set default category, that the user will see first
            ProductList productList = new ProductList(ingredientDAL, categoryDAL.GetIngredientCategories()[0]);
            categoryName.Text = categoryDAL.GetIngredientCategories()[0].Name;
            MainGrid.Children.Add(productList);
            // Add Navigator
            MainGrid.Children.Add(new Navigator(categoryDAL, categoryDAL.GetIngredientCategories(), productList, categoryName));
        }

        public int Type { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
