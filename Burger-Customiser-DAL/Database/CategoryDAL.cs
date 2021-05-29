using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
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
    }
}
