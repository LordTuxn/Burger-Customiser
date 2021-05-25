using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL {

    public class Category {

        [Key, Column("C_ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Type")]
        public int Type { get; set; }

        [Column("BackgroundImage")]
        public string BackgroundImage { get; set; }
    }
}
