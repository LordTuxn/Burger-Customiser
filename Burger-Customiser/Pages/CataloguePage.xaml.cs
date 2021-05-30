using Burger_Customiser.UserControls;
using Burger_Customiser_DAL.Database;
using System.Windows.Controls;

namespace Burger_Customiser.Pages {

    public enum CatalogueType {
        Ingredient = 0,
        Product = 1
    }

    /// <summary>
    /// Interaction logic for Catalogue.xaml
    /// </summary>
    public partial class CataloguePage : Page {
        public CataloguePage(PageManager pm, ArticleDAL articleDAL, CategoryDAL categoryDAL) {
            Type = pm.CatalogueType == 0 ? CatalogueType.Ingredient : CatalogueType.Product; //TODO: Get that somehow else...

            InitializeComponent();

            // Set Header
            title.Text = Type == CatalogueType.Ingredient ? "Burger Zusammenstellung" : "Produkt Katalog";

            // Add ItemList
            // Set default category, that the user will see first
            CatalogueList catalogueList = new CatalogueList(articleDAL, Type, categoryDAL.GetCategoriesByType((int)Type)[0].ID);
            categoryName.Text = categoryDAL.GetCategoriesByType((int)Type)[0].Name;
            MainGrid.Children.Add(catalogueList);

            // Add Navigator
            MainGrid.Children.Add(new Navigator(categoryDAL, catalogueList, categoryName));
        }

        public CatalogueType Type { get; set; }
    }
}