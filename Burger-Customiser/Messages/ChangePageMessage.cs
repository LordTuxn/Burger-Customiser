using System;

namespace Burger_Customiser.Messages {

    public enum CatalogueType {
        Ingredient, Product
    }

    public class ChangePageMessage {

        public Type ViewModelType { get; }

        public CatalogueType CatalogueType { get; set; }

        public ChangePageMessage(Type viewModelType, CatalogueType type = CatalogueType.Ingredient) {
            ViewModelType = viewModelType;
            CatalogueType = type;
        }
    }
}