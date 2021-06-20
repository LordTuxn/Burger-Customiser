using System;
using System.Collections.Generic;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser.Pages.Catalogue;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.ShoppingCart {
    public class ShoppingCartPageVM : PageViewModelBase {

        public List<ProductCartItem> ProductCartItems { get; private set; }
        public List<BurgerCartItem> BurgerCartItems { get; private set; }


        [Obsolete("Only for design data!", true)]
        public ShoppingCartPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public ShoppingCartPageVM(ILogger<ShoppingCartPageVM> logger) {
            //BurgerCartItems = 
        }

        public override NavigationButton GetBackButton() {
            return new NavigationButton("ZURÜCK", onClick => {
                Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
            });
        }

        public override NavigationButton GetContinueButton() { return null; }
    }
}
