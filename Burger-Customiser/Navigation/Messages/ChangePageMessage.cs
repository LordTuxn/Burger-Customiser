using System;

namespace Burger_Customiser.Navigation.Messages {

    public class ChangePageMessage {
        public Type ViewModelType { get; private set; }

        public ChangePageMessage(Type viewModelType) {
            ViewModelType = viewModelType;
        }
    }
}