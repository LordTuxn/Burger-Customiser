using System;
using System.Collections.Generic;
using System.ComponentModel;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser.Pages.Catalogue;
using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.ShoppingCart {
    public class ShoppingCartPageVM : PageViewModelBase, INotifyPropertyChanged {

        public List<ProductCartItem> ProductCartItems { get; private set; }
        public List<BurgerCartItem> BurgerCartItems { get; private set; }

        private OrderManager orderManager;

        public new event PropertyChangedEventHandler PropertyChanged;

        [Obsolete("Only for design data!", true)]
        public ShoppingCartPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public ShoppingCartPageVM(ILogger<ShoppingCartPageVM> logger, OrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        public override NavigationButton GetBackButton() {
            return new NavigationButton("ZURÜCK", onClick => {
                Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
            });
        }

        public override NavigationButton GetContinueButton() { return null; }

        private void UpdateShoppingCartItems()
        {
            // Update Products
            foreach (OrderProduct orderProduct in orderManager.Order.ProductOrders)
            {
                ProductCartItems.Add(new ProductCartItem(orderProduct.Product));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductCartItems"));
            // Update Burgers
            //TODO: -
        }
    }
}
