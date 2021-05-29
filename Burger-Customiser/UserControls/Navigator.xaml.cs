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

namespace Burger_Customiser.UserControls {
    /// <summary>
    /// Interaction logic for Navigator.xaml
    /// </summary>
    public partial class Navigator : UserControl {

        private readonly CategoryDAL categoryDAL;
        private readonly CatalogueList catalogueList;
        private readonly TextBlock categoryName;

        private readonly List<Category> categories;

        public Navigator(CategoryDAL categoryDAL, CatalogueList catalogueList, TextBlock categoryName) {
            InitializeComponent(); 

            this.categoryDAL = categoryDAL;
            this.catalogueList = catalogueList;
            this.categoryName = categoryName;

            categories = catalogueList.Type == CatalogueType.Product ?
                categoryDAL.GetProductCategories() : categoryDAL.GetIngriedentCategories();

            Grid.SetRow(this, 3);
            SetNavigator(categories);
        }

        private void SetNavigator(List<Category> list) {
            foreach (Category item in list) {
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

        void BtnClick(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            categoryName.Text = button.Content.ToString();
            catalogueList.ChangeCategory(categoryDAL.GetCategoryByName(categoryName.Text));
        }
    }
}