using System;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.ShoppingCart {
    public class ShoppingCartPageVM : PageViewModelBase {

        [Obsolete("Only for design data!", true)]
        public ShoppingCartPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public ShoppingCartPageVM(ILogger<ShoppingCartPageVM> logger) {

        }

        public override NavigationButton GetBackButton() {
            return new NavigationButton("ZURÜCK", onClick => {
                Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
            });
        }

        public override NavigationButton GetContinueButton() { return null; }
    }
}
