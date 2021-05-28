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
    /// Interaction logic for BurgerCustomiser.xaml
    /// </summary>
    public partial class BurgerCustomiser : Page
    {
        public BurgerCustomiser(IngredientDAL ingredientDAL, StartWindow startWindow)
        {
            InitializeComponent();
            _startWindow = startWindow;
            MainGrid.Children.Add(new ProductList(ingredientDAL,4));
        }

        private StartWindow _startWindow;
    }
}