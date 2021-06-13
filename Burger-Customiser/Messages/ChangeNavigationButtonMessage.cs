using System.Windows.Controls;

namespace Burger_Customiser.Messages {

    public enum NavigationButton {
        Back, Continue
    }

    public class ChangeNavigationButtonMessage {

        public NavigationButton ButtonType { get; set; }

        public Button Button { get; set; }

        public ChangeNavigationButtonMessage(NavigationButton buttonType, Button button) {
            ButtonType = buttonType;
            Button = button;
        }
    }
}
