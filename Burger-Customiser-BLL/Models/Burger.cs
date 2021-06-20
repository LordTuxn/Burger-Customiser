using Burger_Customiser_BLL.Relationships;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL {

    public class Burger {

        [Column("B_ID")]
        public int ID { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }
        
        public List<BurgerIngredient> BurgerIngredients { get; set; }

        public List<OrderBurger> BurgerOrders { get; set; }
    }
}