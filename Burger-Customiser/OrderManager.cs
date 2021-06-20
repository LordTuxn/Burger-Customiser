using System.Collections.Generic;
using System.Linq;
using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using Burger_Customiser_DAL.Database;

namespace Burger_Customiser {
    public class OrderManager {
        private readonly OrderDAL _orderDAL;

        public Order Order { get; set; }

        public OrderManager(OrderDAL orderDAL) {
            _orderDAL = orderDAL;

            Order = new Order { ProductOrders = new List<OrderProduct>(), BurgerOrders = new List<OrderBurger>() };
        }

        public void AddProduct(Product product, int amount) {
            OrderProduct orderProduct = new OrderProduct() {
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
    }
}
