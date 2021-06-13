using System;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.Start {

    public class StartPageVM : PageViewModelBase {

        [Obsolete("Only for design data!", true)]
        public StartPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public StartPageVM(ILogger<StartPageVM> logger) {
            logger.LogInformation($"Successfully Registered: {nameof(StartPageVM)}");
        }

        public override NavigationButton GetBackButton() { return null; }

        public override NavigationButton GetContinueButton() { return null; }
    }
}