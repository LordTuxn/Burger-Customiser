using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {
    public class CategoryDAL {

        private readonly ApplicationDBContext context;

        public CategoryDAL(ApplicationDBContext context) {
            this.context = context;
        }

        public Category GetCategoryByName(string name) {
            return context.Category.FromSqlRaw("SELECT * FROM category WHERE Name = {0}", name).ToList()[0];
        }

        public Category GetCategoryByID(int id)
        {
            return context.Category.FromSqlRaw("SELECT * FROM category WHERE C_ID = {0}", id).ToList()[0];
        }

        public List<Category> GetProductCategories()
        {
            return context.Category.FromSqlRaw("SELECT * FROM category WHERE type = 1").ToList();
        }

        public List<Category> GetIngredientCategories()
        {
            return context.Category.FromSqlRaw("SELECT * FROM category WHERE type = 1").ToList();
        }
    }
}
