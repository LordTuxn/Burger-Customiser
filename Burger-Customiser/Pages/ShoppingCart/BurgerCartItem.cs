using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burger_Customiser.Pages.ShoppingCart
{
    public class BurgerCartItem : ViewModelBase
    {
        private int _amount;
        public int Amount
        {
            get => _amount;
            set => Set(ref _amount, value);
        }

        public string FormattedPrice { get; }

        public BurgerCartItem ()
        {

        }
    }
}
