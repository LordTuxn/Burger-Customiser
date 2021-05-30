﻿using Burger_Customiser.Pages;
using Burger_Customiser_BLL;
using Burger_Customiser_DAL.Database;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Burger_Customiser.UserControls {
    /// <summary>
    /// User Control List of all Products/Ingredients of one category
    /// </summary>

    public partial class CatalogueList : UserControl {
        public Dictionary<Article, int> articleOrders = new Dictionary<Article, int>();

        private readonly ArticleDAL articleDAL;

        public CatalogueType Type { get; set; }

        public int CurrentCategory { get; set; }

        public CatalogueList(ArticleDAL articleDAL, CatalogueType type, int categoryID) {
            InitializeComponent();

            this.CurrentCategory = categoryID;
            this.articleDAL = articleDAL;
            Type = type;

            Grid.SetRow(this, 7);
            UpdateList();
        }

        public void UpdateList() {
            ClearListItems();
            List<Article> articles = Type == CatalogueType.Product ?
                articleDAL.GetProductsByCategory(CurrentCategory).ConvertAll(x => new Article { Name = x.Name, Price = x.Price }) :
                articleDAL.GetIngredientsByCategory(CurrentCategory).ConvertAll(x => new Article { Name = x.Name, Price = x.Price }); // "Cast" the whole Product and Ingredient List to a universal Article List

            foreach (Article article in articles) {
                ProductListWrapPanel.Children.Add(new ProductItem(this, article, 0) {
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

            // Add back the grid again
            Grid grid = new Grid { Width = 800 };
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            ProductListWrapPanel.Children.Add(grid);
        }
    }
}