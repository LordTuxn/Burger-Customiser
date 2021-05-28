﻿using Burger_Customiser_DAL.Database;
using System;
using System.Windows.Controls;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for BurgerCustomiser.xaml
    /// </summary>
    public partial class BurgerCustomiserPage : Page { // Add IDisposable interface to fix memory leaks

        private readonly PageManager pageManager;
        private readonly IngredientDAL ingredientDAL;

        public BurgerCustomiserPage(PageManager pageManager, IngredientDAL ingredientDAL) {
            this.pageManager = pageManager;
            this.ingredientDAL = ingredientDAL;

            InitializeComponent();
        }
    }
}
