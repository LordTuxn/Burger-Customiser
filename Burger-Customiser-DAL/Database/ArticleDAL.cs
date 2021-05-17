using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {
    public class ArticleDAL {

        private readonly IDbContextFactory<ApplicationDBContext> contextFactory;

        public ArticleDAL(IDbContextFactory<ApplicationDBContext> contextFactory) {
            this.contextFactory = contextFactory;
        }

        public List<Article> getArticles() {
            using(var context = contextFactory.CreateDbContext()) {
                return context.Article.FromSqlRaw("SELECT * FROM articles").ToList();
            }
        }
    }
}
