using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using GalaSoft.MvvmLight;

namespace Burger_Customiser.Pages.ShoppingCart {

    public class BurgerCartItem : ViewModelBase {
        public Burger Burger { get; }

        private int _amount;

        public int Amount {
            get => _amount;
            set => Set(ref _amount, value);
        }

        public string FormattedPrice { get; }

        public BurgerCartItem(Burger burger, int amount) {
            this.Burger = burger;
            Amount = amount;
            decimal price = 0;

            foreach (BurgerIngredient item in Burger.BurgerIngredients) {
                price += item.Ingredient.Price * item.Amount;
            }
            Burger.Price = price;
            FormattedPrice = $"{price} €";
        }
    }
}