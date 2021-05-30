using Burger_Customiser_BLL.Relationships;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL {

    public class Order {

        [Key, Column("O_ID")]
        public int ID { get; set; }

        [Column("OrderData")]
        public DateTime OrderDate { get; set; }

        [Column("ToTakeAway")]
        public bool ToTakeAway { get; set; }

        public List<OrderProduct> ProductOrders { get; set; }

        public List<OrderBurger> BurgerOrders { get; set; }
    }
}