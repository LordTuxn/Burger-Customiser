using System;

namespace Burger_Customiser.Messages {

    public class ChangePageMessage {
        public Type ViewModelType { get; }

        public ChangePageMessage(Type viewModelType) {
            ViewModelType = viewModelType;
        }
    }
}