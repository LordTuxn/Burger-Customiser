namespace Burger_Customiser.Messages {

    public enum CatalogueType {
        Ingredient, Product
    }

    public class ChangeCatalogueTypeMessage {

        public CatalogueType CatalogueType { get; }

        public ChangeCatalogueTypeMessage(CatalogueType catalogueType) {
            CatalogueType = catalogueType;
        }

    }
}
