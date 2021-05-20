using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {
    public class ArticleDAL {

        private readonly ILogger<ArticleDAL> logger;
        private readonly ApplicationDBContext context;

        public ArticleDAL(ILogger<ArticleDAL> logger, ApplicationDBContext context) {
            this.logger = logger;
            this.context = context;
        }

        public List<Article> getArticles () { 
            return context.Article.FromSqlRaw("SELECT * FROM article").ToList();
        }
    }
}
