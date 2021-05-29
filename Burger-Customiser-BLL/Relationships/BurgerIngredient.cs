using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL.Relationships {
    [Table("Burger_Has_Ingredient")]
    public class BurgerIngredient {

        [Key, ForeignKey("Burger"), Column("B_ID")]
        public int BurgerID { get; set; }
        public Burger Burger { get; set; }

        [ForeignKey("Ingredient"), Column("I_ID")]
        public int IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }

        [ForeignKey("Category"), Column("C_ID")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Column("Amount")]
        public int Amount { get; set; }
    }
}
