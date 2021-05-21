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
        public Artikeloption(StartWindow startWindow)
        {
            InitializeComponent();
            _startWindow = startWindow;
        }

        private StartWindow _startWindow;

        private void BurgerLMBDown(object sender, MouseButtonEventArgs e)
        {
            _startWindow.Main.Content = new BurgerCustomiser(_startWindow);
        }

        private void CatalogueLMBDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
