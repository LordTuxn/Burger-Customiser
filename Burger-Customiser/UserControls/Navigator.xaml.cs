using Burger_Customiser_BLL;
using Burger_Customiser_DAL.Database;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

            categories = categoryDAL.GetCategoriesByType((int)catalogueList.Type);

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
                img.Opacity = 0.7;

                // Get Style
                Style style = this.FindResource("NavigatorButton") as Style;

                Button btn = new Button() {
                    Style = style,
                    Content = item.Name,
                    Background = img
                };
                btn.Click += new RoutedEventHandler(BtnClick);
                NavigationWrapPanel.Children.Add(btn);
            }
        }

        private void BtnClick(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            categoryName.Text = button.Content.ToString();
            catalogueList.ChangeCategory(categoryDAL.GetCategoryByName(categoryName.Text));
        }
    }
}