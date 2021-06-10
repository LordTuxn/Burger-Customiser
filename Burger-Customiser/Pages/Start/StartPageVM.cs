using System;
using GalaSoft.MvvmLight;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.Start {

    public class StartPageVM : ViewModelBase, IPageViewModel {

        [Obsolete("Only for design data!", true)]
        public StartPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public StartPageVM(ILogger<StartPageVM> logger) {
            logger.LogInformation($"Successfully Registered: {nameof(StartPageVM)}");
        }

        public void ContinuePage() {
            throw new NotImplementedException();
        }

        public void BackPage() {
            throw new NotImplementedException();
        }
    }
}