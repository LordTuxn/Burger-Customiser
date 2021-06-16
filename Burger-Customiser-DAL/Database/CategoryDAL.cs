using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {

    public class CategoryDAL {
        private readonly ApplicationDbContext context;

        public CategoryDAL(ApplicationDbContext context) {
            this.context = context;
        }

        public Category GetCategoryById(int id) {
            return context.Category.FromSqlRaw("SELECT * FROM category WHERE C_ID = {0}", id).ToList()[0];
        }

        public List<Category> GetCategoriesByType(int typeId) {
            return context.Category.FromSqlRaw("SELECT * FROM category WHERE type = {0}", typeId).ToList();
        }
    }
}