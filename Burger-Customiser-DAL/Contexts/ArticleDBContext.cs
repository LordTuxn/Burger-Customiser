using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Burger_Customiser_DAL {
    public class ArticleDBContext : DbContext {

        public DbSet<Article> Article { get; set; }

        public ArticleDBContext(DbContextOptions<ArticleDBContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public Article getArticleByID(int ID) {
            return Article.FromSqlRaw("SELECT * FROM Artikel WHERE Artikel-ID = {0}", ID).ToList()[0];
        }
    }
}
