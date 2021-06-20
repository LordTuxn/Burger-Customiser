using GalaSoft.MvvmLight;

namespace Burger_Customiser.Pages {

    public abstract class PageViewModelBase : ViewModelBase {

        public abstract NavigationButton GetBackButton();

        public abstract NavigationButton GetContinueButton();
    }
}