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
    /// Interaction logic for NavigationFooter.xaml
    /// </summary>
    public partial class NavigationFooter : UserControl
    {
        public NavigationFooter(PageManager pm)
        {
            InitializeComponent();
            Grid.SetColumn(this, 1);
            Grid.SetRow(this, 4);
            this.pageManager = pm;
        }

        private readonly PageManager pageManager;

        private void Button_Next_Click(object sender, RoutedEventArgs e) {
            pageManager.NextPage();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e) {
            pageManager.PreviousPage();
        }
    }
}
