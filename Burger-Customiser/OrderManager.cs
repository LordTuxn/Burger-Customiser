using Burger_Customiser.Messages;
using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser {

    public class OrderManager {
        public Order Order { get; set; }

        public OrderManager() {
            Order = new Order { ProductOrders = new List<OrderProduct>(), BurgerOrders = new List<OrderBurger>() };

            Messenger.Default.Register<ChangeToTakeAwayOptionMessage>(this, ChangeToTakeAwayOption);
        }

        public void AddProduct(Product product, int amount) {
            OrderProduct orderProduct = new OrderProduct {
                Order = Order,
                Product = product,
                CategoryID = product.CategoryID,
                Amount = amount
            };

            if (Order.ProductOrders.Any(x => x.ProductID == product.ID)) {
                Order.ProductOrders.Remove(Order.ProductOrders.Find(x => x.Product.ID == product.ID));
            }

            Order.ProductOrders.Add(orderProduct);
        }

        public void AddBurger(Burger burger, int amount) {
            Order.BurgerOrders.Add(
                new OrderBurger {
                    Order = Order,
                    Burger = burger,
                    Amount = amount
                });
        }

        public void ChangeToTakeAwayOption(ChangeToTakeAwayOptionMessage option) {
            Order.ToTakeAway = option.ToTakeAway;
        }
    }
}