using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL {
    public class Product {

        [Key, Column("P_ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("BackgroundImage")]
        public string BackgroundImageLink { get; set; }

        [ForeignKey("Category"), Column("C_ID")]
        public int CategoryID { get; set; }
    }
}
