using Burger_Customiser_BLL;
using Burger_Customiser_DAL.Database;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Burger_Customiser.UserControls {
    /// <summary>
    /// User Control List of all Products/Ingredients of one category
    /// </summary>
    /// 

    public enum CatalogueType {
        Ingredient, 
        Product
    }

    public partial class CatalogueList : UserControl {

        private readonly ArticleDAL articleDAL;

        public CatalogueType Type { get; set; }

        public int CurrentCategory { get; set; }

        public CatalogueList(ArticleDAL articleDAL, CatalogueType type) {
            InitializeComponent();

            this.articleDAL = articleDAL;
            Type = type;

            Grid.SetRow(this, 7);
            UpdateList();
        }
        
        public void UpdateList() {
            ClearListItems();

            List<Article> articles = Type == CatalogueType.Product ?
                articleDAL.GetProductsByCategory(CurrentCategory).ConvertAll(x => new Article { Name = x.Name, Price = x.Price }) :
                articleDAL.GetIngredientsByCategory(CurrentCategory).ConvertAll(x => new Article { Name = x.Name, Price = x.Price }); // TODO: Description
            
            foreach (Article article in articles) {
                ProductListWrapPanel.Children.Add(new ProductItem(article.Name, 0, (double)article.Price) {
                    Height = 60,
                    Margin = new Thickness(10, 10, 10, 0)
                });
            }
        }

        public void ChangeCategory(Category category) {
            CurrentCategory = category.ID;
            UpdateList();
        }

        private void ClearListItems() {
            // Clear every single child including the grid
            ProductListWrapPanel.Children.Clear();

            // Add the grid back again
            Grid grid = new Grid { Width = 800 };
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            ProductListWrapPanel.Children.Add(grid);
        }
    }
}
