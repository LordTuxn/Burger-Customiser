using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {
    public class ProductDAL {

        private readonly ILogger<ProductDAL> logger;
        private readonly ApplicationDBContext context;

        public ProductDAL(ILogger<ProductDAL> logger, ApplicationDBContext context) {
            this.logger = logger;
            this.context = context;
        }

        public List<Product> getProducts () {
            return context.Product.FromSqlRaw("SELECT * FROM product").ToList();
        }

        public List<Category> getCategories() {
            return context.Category.FromSqlRaw("SELECT * FROM category WHERE Type = 1").ToList();
        }
    }
}
