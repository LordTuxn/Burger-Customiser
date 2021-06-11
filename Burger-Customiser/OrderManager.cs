using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using Burger_Customiser_DAL.Database;

namespace Burger_Customiser {

    public class OrderManager {
        private readonly OrderDAL orderDAL;

        public Order Order { get; set; }

        public OrderManager(OrderDAL orderDAL) {
            this.orderDAL = orderDAL;

            Order = new Order();
        }

        public void AddProduct(Product product, int amount) {
            Order.ProductOrders.Add(
                new OrderProduct() {
                    Order = Order,
                    Product = product,
                    CategoryID = product.CategoryID,
                    Amount = amount
                });
        }

        public void AddBurger(Burger burger, int amount) {
            Order.BurgerOrders.Add(
                new OrderBurger() {
                    Order = Order,
                    Burger = burger,
                    Amount = amount
                });
        }
    }
}