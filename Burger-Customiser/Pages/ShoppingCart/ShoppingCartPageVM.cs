using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser_BLL.Relationships;
using Burger_Customiser_DAL.Database;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Burger_Customiser.Pages.ShoppingCart {

    public class ShoppingCartPageVM : PageViewModelBase, INotifyPropertyChanged {
        public List<ProductCartItem> ProductCartItems { get; private set; }
        public List<BurgerCartItem> BurgerCartItems { get; private set; }

        public string TakeAwayOption => orderManager.Order.ToTakeAway ? "Zum Mitnehmen" : "Zum hier Essen";

        private decimal totalCostEUR = 0;

        public string TotalCost {
            get {
                decimal totalCost = 0;
                foreach (ProductCartItem item in ProductCartItems) {
                    totalCost += item.Product.Price * item.Amount;
                }

                foreach (BurgerCartItem item in BurgerCartItems)
                {
                    totalCost += item.Burger.Price * item.Amount;
                }
                totalCostEUR = totalCost;
                return $"{totalCost} €";
            }
        }

        private readonly ILogger<ShoppingCartPageVM> logger;
        public OrderManager orderManager;
        private readonly OrderDAL _orderDAL;
        private readonly BurgerDAL _burgerDAL;

        public new event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand<string> AddArticleToShoppingCart { get; }
        public RelayCommand<string> RemoveArticleFromShoppingCart { get; }
        public RelayCommand CompleteOrder { get; }

        [Obsolete("Only for design data!", true)]
        public ShoppingCartPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public ShoppingCartPageVM(ILogger<ShoppingCartPageVM> logger, OrderManager orderManager, OrderDAL orderDAL, BurgerDAL burgerDAL) {
            this.logger = logger;
            this.orderManager = orderManager;
            _orderDAL = orderDAL;
            _burgerDAL = burgerDAL;

            AddArticleToShoppingCart = new RelayCommand<string>(Add_ArticleToShoppingCart);
            RemoveArticleFromShoppingCart = new RelayCommand<string>(Remove_ArticleFromShoppingCart);
            CompleteOrder = new RelayCommand(Complete_Order);
        }

        public override NavigationButton GetBackButton() {
            return new NavigationButton("ZURÜCK", onClick => {
                Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
            });
        }

        public override NavigationButton GetContinueButton() {
            return null;
        }

        private void Add_ArticleToShoppingCart(string articleName) {
            //TODO: Update
        }

        private void Remove_ArticleFromShoppingCart(string articleName) {
            //TODO: Remove if 0 & update
        }

        private void Complete_Order() {
            // TODO: Complete Order

            // Das speichern der Bestellung in die Datenbank fehlt uns leider noch komplett, da es uns aus
            // zeitlichen Gründen nicht mehr ausgegangen ist und uns zusätzlich aufgefallen ist, dass wir noch ein paar
            // Sachen im Code davor ändern müssen...
        }

        public void UpdateShoppingCartItems() {
            // Update Products
            List<ProductCartItem> productCartItems = new List<ProductCartItem>();
            foreach (OrderProduct orderProduct in orderManager.Order.ProductOrders) {
                productCartItems.Add(new ProductCartItem(orderProduct.Product, orderProduct.Amount));
            }

            ProductCartItems = productCartItems;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductCartItems"));

            // Update Burgers
            List<BurgerCartItem> burgerCartItems = new List<BurgerCartItem>();
            foreach (OrderBurger orderBurger in orderManager.Order.BurgerOrders) {
                logger.LogInformation("Burger: " + orderBurger.Burger.BurgerIngredients.Count);
                burgerCartItems.Add(new BurgerCartItem(orderBurger.Burger, orderBurger.Amount));
            }

            BurgerCartItems = burgerCartItems;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BurgerCartItems"));
        }
    }
}