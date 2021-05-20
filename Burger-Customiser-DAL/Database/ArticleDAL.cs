using Burger_Customiser_BLL;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Burger_Customiser_DAL.Database {
    public class ArticleDAL {

        private readonly ApplicationDBContext context;

        public ArticleDAL(ApplicationDBContext context) {
            this.context = context;
        }

        public string getArticleName (ILogger logger, int id) {
            try {
                context.Database.Connection.Open();
                logger.LogInformation(context.Database.Connection.ConnectionString);
                return context.Article.Find(id).Name;

            } catch(Exception ex) {
                logger.LogError(ex.StackTrace);
            }
            return "Error";
        }
    }
}
