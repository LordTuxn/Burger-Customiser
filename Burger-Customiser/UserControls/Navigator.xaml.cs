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
        public Navigator(CategoryDAL categoryDAL, List<Category> categories, ProductList productList, TextBlock categoryName)
        {
            InitializeComponent();
            Grid.SetRow(this, 3);
            this.productList = productList;
            this.categories = categories;
            this.categoryName = categoryName;
            this.categoryDAL = categoryDAL;
            SetNavigator(categories);
        }

        private readonly ProductList productList;
        private readonly List<Category> categories;
        private readonly TextBlock categoryName;
        private readonly CategoryDAL categoryDAL;

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
                btn.Click += new RoutedEventHandler(BtnClick);
                NavigationWrapPanel.Children.Add(btn);
            }
        }

        void BtnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            categoryName.Text = button.Content.ToString();
            productList.ChangeCategory(categoryDAL.GetCategoryByName(categoryName.Text));
        }
    }
}