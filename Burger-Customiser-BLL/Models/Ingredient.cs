using Burger_Customiser_BLL.Relationships;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL {
    public class Ingredient {

        [Key, Column("I_ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("InStock")]
        public int InStock { get; set; }

        [Column("BackgroundImage")]
        public string BackgroundImage { get; set; }

        [ForeignKey("Category"), Column("C_ID")]
        public int CategoryID { get; set; }

        public List<BurgerIngredient> BurgerIngredient { get; set; }
    }
}
