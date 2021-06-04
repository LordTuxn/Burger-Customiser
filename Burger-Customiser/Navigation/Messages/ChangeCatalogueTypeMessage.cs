namespace Burger_Customiser.Navigation.Messages {
    public class ChangeCatalogueTypeMessage {

        public enum CatalogueType {
            Ingredient, Product
        }

        public CatalogueType Type { get; set; }

        public ChangeCatalogueTypeMessage(CatalogueType type) {
            Type = type;
        }
    }
}
