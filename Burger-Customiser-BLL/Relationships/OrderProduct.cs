using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL.Relationships {

    [Table("Order_Has_Product")]
    public class OrderProduct {

        [Key, ForeignKey("Order"), Column("O_ID")]
        public int OrderID { get; set; }

        public Order Order { get; set; }

        [ForeignKey("Product"), Column("P_ID")]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        [ForeignKey("Category"), Column("C_ID")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        [Column("Amount")]
        public int Amount { get; set; }
    }
}