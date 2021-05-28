using Burger_Customiser_BLL;
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

namespace Burger_Customiser.UserControls
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : UserControl
    {
        public ProductList(IngredientDAL ingredientDAL, int categoryID)
        {
            InitializeComponent();
            this.ingredientDAL = ingredientDAL;
            this.categoryID = categoryID;
            Grid.SetRow(this, 7);
            UpdateList();
        }

        private IngredientDAL ingredientDAL;
        private int categoryID;
        
        public void UpdateList()
        {
            List<Ingredient> ingredients = ingredientDAL.GetIngredientsByCategory(categoryID);
            foreach (Ingredient item in ingredients)
            {
                ProductListWrapPanel.Children.Add(new ProductItem(item.Name, 0, (double)item.Price)
                {
                    Height = 60,
                    Margin = new Thickness(10, 10, 10, 0)
                });
            }
        }

        public void ChangeCategory(int categoryID)
        {
            this.categoryID = categoryID;
            UpdateList();
        }
    }
}
