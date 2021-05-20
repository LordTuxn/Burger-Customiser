using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL {
    public class Article {

        [Key, Column("A_ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        // TODO: Type

        // TODO: Kategorie
    }
}
