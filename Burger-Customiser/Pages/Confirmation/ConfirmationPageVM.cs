using Microsoft.Extensions.Logging;
using System;

namespace Burger_Customiser.Pages.Confirmation {

    public class ConfirmationPageVM : PageViewModelBase {

        [Obsolete("Only for design data!", true)]
        public ConfirmationPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public ConfirmationPageVM(ILogger<ConfirmationPageVM> logger) {
        }

        public override NavigationButton GetBackButton() {
            return null;
        }

        public override NavigationButton GetContinueButton() {
            return null;
        }
    }
}