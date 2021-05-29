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
    /// Interaction logic for Catalogue.xaml
    /// </summary>
    public partial class Catalogue : Page { // Add IDisposable interface to fix memory leaks

        private readonly PageManager pageManager;
        private readonly ArticleDAL articleDAL;

        public Catalogue(PageManager pm, ArticleDAL articleDAL, CategoryDAL categoryDAL) {
            this.pageManager = pm;
            this.articleDAL = articleDAL;

            // Add ItemList
            // Set default category, that the user will see first
            CatalogueList catalogueList = new CatalogueList(articleDAL, CatalogueType.Ingredient);
            //categoryName.Text = categoryDAL.GetIngredientCategories()[0].Name;
            MainGrid.Children.Add(catalogueList);
            // Add Navigator
            MainGrid.Children.Add(new Navigator(categoryDAL, catalogueList, categoryName));

            InitializeComponent();
        }

        public int Type { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
