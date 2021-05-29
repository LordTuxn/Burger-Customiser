using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL.Relationships {
    [Table("Order_Has_Burger")]
    public class OrderBurger {

        [Key, ForeignKey("Order"), Column("O_ID")]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Burger"), Column("B_ID")]
        public int BurgerID { get; set; }
        public Burger Burger { get; set; }

        [Column("Amount")]
        public int Amount { get; set; }
    }
}
