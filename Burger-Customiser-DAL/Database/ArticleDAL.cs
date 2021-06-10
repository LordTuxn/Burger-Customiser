using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {

    public class ArticleDAL {
        private readonly ApplicationDbContext context;

        public ArticleDAL(ApplicationDbContext context) {
            this.context = context;
        }

        public List<Ingredient> GetIngredientsByCategory(int categoryID) {
            return context.Ingredient.FromSqlRaw("SELECT * FROM article WHERE C_ID = {0}", categoryID).ToList();
        }

        public List<Product> GetProductsByCategory(int categoryID) {
            return context.Product.FromSqlRaw("SELECT * FROM article WHERE C_ID = {0}", categoryID).ToList();
        }

        public void UpdateIngredient(Ingredient ingredient) {
            context.Update(ingredient);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product) {
            context.Update(product);
            context.SaveChanges();
        }
    }
}