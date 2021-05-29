using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using Burger_Customiser_DAL.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burger_Customiser {
    public class OrderManager : IDisposable {

        private readonly OrderDAL orderDAL;

        public Order Order { get; set; }

        public OrderManager(OrderDAL orderDAL) {
            this.orderDAL = orderDAL;

            Order = new Order();
        }



        public void Dispose() {
            Dispose();
        }
    }
}
