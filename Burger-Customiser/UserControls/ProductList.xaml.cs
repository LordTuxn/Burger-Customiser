using Burger_Customiser_BLL;
using Burger_Customiser_DAL.Database;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Burger_Customiser.UserControls
{
    /// <summary>
    /// User Control List of all Products/Ingredients of one category
    /// </summary>
    public partial class ProductList : UserControl
    {
        // Constructor for Ingredients
        public ProductList(IngredientDAL ingredientDAL, Category category)
        {
            InitializeComponent();
            this.ingredientDAL = ingredientDAL;
            this.category = category;
            Grid.SetRow(this, 7);
            UpdateList();
        }

        //Constructor for Products
        public ProductList(ProductDAL productDAL, Category category) : this((IngredientDAL)null, category)
        {
            this.productDAL = productDAL;
        }

        private IngredientDAL ingredientDAL;
        private ProductDAL productDAL;
        private Category category;
        
        public void UpdateList()
        {
            ClearListItems();
            // because we dont have a class that is inherited by both ingredients and products, we have to do this awful shit... i am sincerely sorry... please dont kill us... have mercy.... help.... :kms:...........
            // I cant........ it hurts..... make it stop.............
            // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHH
            // https://cdn.discordapp.com/emojis/340532805782208512.png
            if (ingredientDAL == null)
            {
                List<Product> products = productDAL.GetProductsByCategory(category.ID);
                foreach (Product item in products)
                {
                    ProductListWrapPanel.Children.Add(new ProductItem(item.Name, 0, (double)item.Price)
                    {
                        Height = 60,
                        Margin = new Thickness(10, 10, 10, 0)
                    });
                }
            } else
            {
                List<Ingredient> ingredients = ingredientDAL.GetIngredientsByCategory(category.ID);
                foreach (Ingredient item in ingredients)
                {
                    ProductListWrapPanel.Children.Add(new ProductItem(item.Name, 0, (double)item.Price)
                    {
                        Height = 60,
                        Margin = new Thickness(10, 10, 10, 0)
                    });
                }
            }
        }

        public void ChangeCategory(Category category)
        {
            this.category = category;
            UpdateList();
        }

        private void ClearListItems()
        {
            // Clear every single child including the grid
            ProductListWrapPanel.Children.Clear();

            // Add the grid back again
            Grid grid = new Grid { Width = 800 };
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            ProductListWrapPanel.Children.Add(grid);
        }
    }
}
