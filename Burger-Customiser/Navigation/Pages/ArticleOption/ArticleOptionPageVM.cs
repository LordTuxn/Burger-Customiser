using Burger_Customiser.Navigation.Messages;
using Burger_Customiser.Navigation.Pages.OrderOption;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;
using System;

namespace Burger_Customiser.Navigation.Pages.ArticleOption {
    public class ArticleOptionPageVM : ViewModelBase, IPageViewModel {

        [Obsolete("Only for design data!", true)]
        public ArticleOptionPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public ArticleOptionPageVM(ILogger<ArticleOptionPageVM> logger) {
            logger.LogInformation($"Successfully Registered: {nameof(ArticleOptionPageVM)}");
        }

        public void BackPage() {
            Messenger.Default.Send(new ChangePageMessage(typeof(OrderOptionPageVM)));
        }

        public void ContinuePage() {
            throw new NotImplementedException();
        }
    }
}
