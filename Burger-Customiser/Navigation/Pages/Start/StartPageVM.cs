using Burger_Customiser.Navigation.Messages;
using Burger_Customiser.Navigation.Pages.OrderOption;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;
using System;

namespace Burger_Customiser.Navigation.Pages.Start {

    public class StartPageVM : ViewModelBase, IPageViewModel {

        [Obsolete("Only for design data!", true)]
        public StartPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public StartPageVM(ILogger<StartPageVM> logger) {
            logger.LogInformation("Success!");
        }

        public void NextPage() {
            Messenger.Default.Send(new ChangePageMessage(typeof(OrderOptionPageVM)));
        }

        public void PreviousPage() {
            throw new NotImplementedException();
        }
    }
}