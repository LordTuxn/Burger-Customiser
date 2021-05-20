using Burger_Customiser_BLL;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Burger_Customiser_DAL.Database {
    public class ArticleDAL {

        private readonly IDbContextFactory<ApplicationDBContext> contextFactory;

        public ArticleDAL(ILogger logger, IDbContextFactory<ApplicationDBContext> contextFactory) {
            this.contextFactory = contextFactory;

            logger.LogInformation(getArticles()[0].Name);
        }

        public List<Article> getArticles() {
            using(var context = contextFactory.Create()) {
                return context.Article.SqlQuery("SELECT * FROM articles").ToList();
            }
        }
    }
}
