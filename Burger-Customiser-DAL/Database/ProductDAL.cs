using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {
    public class ProductDAL {

        private readonly ApplicationDBContext context;

        public ProductDAL(ApplicationDBContext context) {
            this.context = context;
        }

        public List<Product> GetProducts () {
            return context.Product.FromSqlRaw("SELECT * FROM product").ToList();
        }

        public List<Ingredient> GetIngredientsByCategory(int categoryID) {
            return context.Ingredient.FromSqlRaw("SELECT * FROM products WHERE C_ID = {0}", categoryID).ToList();
        }

        public List<Category> GetCategories() {
            return context.Category.FromSqlRaw("SELECT * FROM category WHERE type = 1").ToList();
        }
    }
}
