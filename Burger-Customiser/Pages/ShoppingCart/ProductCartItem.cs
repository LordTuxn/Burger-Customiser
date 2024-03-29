﻿using Burger_Customiser_BLL;
using GalaSoft.MvvmLight;

namespace Burger_Customiser.Pages.ShoppingCart {

    public class ProductCartItem : ViewModelBase {
        public Product Product { get; }

        private int _amount;

        public int Amount {
            get => _amount;
            set => Set(ref _amount, value);
        }

        public string FormattedPrice { get; }

        public ProductCartItem(Product product, int amount) {
            this.Product = product;
            Amount = amount;

            FormattedPrice = $"{Product.Price} €";
        }
    }
}