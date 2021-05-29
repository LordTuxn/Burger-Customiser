using Burger_Customiser_BLL.Relationships;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL {
    public class Product {
        [Key, Column("P_ID")]
        public int P_ID { get; set; }

        [Column("Name")]
        public string ProductName { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("InStock")]
        public int InStock { get; set; }

        [Column("BackgroundImage")]
        public string ProductBackgroundImage { get; set; }

        [ForeignKey("category"), Column("C_ID")]
        public int CategoryID { get; set; }

        public List<OrderProduct> ProductOrders { get; set; }
    }
}
