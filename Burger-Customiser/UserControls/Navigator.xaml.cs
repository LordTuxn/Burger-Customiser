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
    /// Interaction logic for Navigator.xaml
    /// </summary>
    public partial class Navigator : UserControl
    {
        public Navigator(IngredientDAL ingredientDAL, ProductList productList)
        {
            InitializeComponent();
            Grid.SetRow(this, 3);
            this.productList = productList;
            this.categories = ingredientDAL.GetCategories();
            SetNavigator(categories);
        }

        private ProductList productList;
        private List<Category> categories;

        private void SetNavigator(List<Category> list)
        {
            foreach (Category item in list)
            {
                // Get Image
                string url = item.BackgroundImage.Trim();
                url = (url == "" ? $@"https://i.imgur.com/BnQNYQS.jpg" : item.BackgroundImage); // Check if there is a Background Image in the database, if not set default image

                BitmapImage bitimg = new BitmapImage();
                bitimg.BeginInit();
                bitimg.UriSource = new Uri($@"{url}", UriKind.RelativeOrAbsolute);
                bitimg.EndInit();

                ImageBrush img = new ImageBrush(bitimg);
                img.Stretch = Stretch.UniformToFill;

                Button btn = new Button() {
                    Width = 150,
                    Content = item.Name,
                    Background = img
                };
                NavigationWrapPanel.Children.Add(btn);
            }
        }
    }
}
