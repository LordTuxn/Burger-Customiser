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
    /// Interaction logic for Navigator.xaml
    /// </summary>
    public partial class Navigator : UserControl
    {
        public Navigator()
        {
            InitializeComponent();
            //TODO: Get Categories
            //For now this will do for testing
            Dictionary<string, string> categoryDict = new Dictionary<string, string>();
            categoryDict.Add("Fleisch", "");
            categoryDict.Add("Brot", "");
            categoryDict.Add("Käse", "");
            categoryDict.Add("Beläge", "");

            SetNavigator(categoryDict);
        }

        private void SetNavigator(Dictionary<string, string> dict)
        {
            foreach (KeyValuePair<string, string> entry in dict)
            {
                NavigationWrapPanel.Children.Add(new Button {
                    Width = 150,
                    Content = entry.Key
                });
            }
        }
    }
}
