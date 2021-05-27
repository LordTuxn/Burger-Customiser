using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {
    public class IngredientDAL {

        private readonly ApplicationDBContext context;

        public IngredientDAL(ApplicationDBContext context) {
            this.context = context;
        }

        public List<Ingredient> GetIngredients() {
            return context.Ingredient.FromSqlRaw("SELECT * FROM ingredient").ToList();
        }

        public List<Ingredient> GetIngredientsByCategory(int categoryID) {
            return context.Ingredient.FromSqlRaw("SELECT * FROM ingredient WHERE C_ID = {0}", categoryID).ToList();
        }

        public List<Category> GetCategories() {
            return context.Category.FromSqlRaw("SELECT * FROM category WHERE type = 0").ToList();
        }

       // public void SaveIngredient*
    }
}
