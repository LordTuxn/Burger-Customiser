using System;
using System.Windows.Controls;
using GalaSoft.MvvmLight;

namespace Burger_Customiser.Pages {
    public abstract class PageViewModelBase : ViewModelBase {

        public enum ButtonStyle {
            Default, Catalogue, Order
        }

        private Button _continueButton;
        public Button ContinueButton {
            get => _continueButton;
            set => Set(ref _continueButton, value);
        }

        private Button _backButton;
        public Button BackButton {
            get => _backButton;
            set => Set(ref _backButton, value);
        }

        protected virtual void SetBackButton(ButtonStyle buttonStyle) {
            SetButtonStyle(_backButton, buttonStyle);
        }

        protected virtual void SetContinueButton(ButtonStyle buttonStyle) {
            SetButtonStyle(_continueButton, buttonStyle);
        }

        private static void SetButtonStyle(Button button, ButtonStyle buttonStyle) {
            switch (buttonStyle) {
                case ButtonStyle.Default:
                    
                    break;
                case ButtonStyle.Catalogue:

                    break;
                case ButtonStyle.Order:

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(buttonStyle), buttonStyle, null);
            }
        }
    }
}
