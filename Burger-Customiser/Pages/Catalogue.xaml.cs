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
    public enum CatalogueType
    {
        Ingredient = 0,
        Product = 1
    }

    /// <summary>
    /// Interaction logic for Catalogue.xaml
    /// </summary>
    public partial class Catalogue : Page { // Add IDisposable interface to fix memory leaks


        private readonly PageManager pageManager;
        private readonly ArticleDAL articleDAL;

        public Catalogue(PageManager pm, ArticleDAL articleDAL, CategoryDAL categoryDAL) {
            this.pageManager = pm;
            this.articleDAL = articleDAL;
            this.Type = pm.CatalogueType == 0 ? CatalogueType.Ingredient : CatalogueType.Product; //TODO: Get that somehow else...

            InitializeComponent();

            // Set Header
            title.Text = Type == CatalogueType.Ingredient ? "Burger Customiser" : "Produkt Katalog";

            // Add ItemList
            // Set default category, that the user will see first
            
            CatalogueList catalogueList = new CatalogueList(articleDAL, Type, categoryDAL.GetCategoriesByType((int)Type)[0].ID);
            categoryName.Text = categoryDAL.GetCategoriesByType((int)Type)[0].Name;
            MainGrid.Children.Add(catalogueList);
            // Add Navigator
            MainGrid.Children.Add(new Navigator(categoryDAL, catalogueList, categoryName));
        }

        public CatalogueType Type { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
