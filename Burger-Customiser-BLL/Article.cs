using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burger_Customiser_BLL {
    public class Article {

        [Key, Column("Artikel-ID")]
        public int ID { get; set; }

        [Column("Bezeichnung")]
        public string Name { get; set; }

        [Column("Preis")]
        public double Price { get; set; }

        // TODO: Type

        // TODO: Kategorie
    }
}
