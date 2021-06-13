using System;
using System.Windows.Controls;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.OrderOption;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.ArticleOption {
    public class ArticleOptionPageVM : PageViewModelBase {

        [Obsolete("Only for design data!", true)]
        public ArticleOptionPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public ArticleOptionPageVM(ILogger<ArticleOptionPageVM> logger) {
            logger.LogInformation($"Successfully Registered: {nameof(ArticleOptionPageVM)}");
        }

        public override NavigationButton GetBackButton() {
            return new NavigationButton("ZURÜCK", onClick => {
                Messenger.Default.Send(new ChangePageMessage(typeof(OrderOptionPageVM)));
            });
        }

        public override NavigationButton GetContinueButton() { return null; }
    }
}
