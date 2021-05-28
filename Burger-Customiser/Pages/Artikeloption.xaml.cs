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
    /// Interaction logic for Artikeloption.xaml
    /// </summary>
    public partial class Artikeloption : Page
    {
        public Artikeloption(IngredientDAL ingredientDAL, StartWindow startWindow)
        {
            InitializeComponent();
            _startWindow = startWindow;
            this.ingredientDAL = ingredientDAL;
        }

        private StartWindow _startWindow;
        private IngredientDAL ingredientDAL;

        private void BurgerLMBDown(object sender, MouseButtonEventArgs e)
        {
            _startWindow.Main.Content = new BurgerCustomiser(ingredientDAL, _startWindow);
        }

        private void CatalogueLMBDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
