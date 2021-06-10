using System;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.OrderOption;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.ArticleOption {
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
