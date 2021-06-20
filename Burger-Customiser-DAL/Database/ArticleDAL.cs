using System;
using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Burger_Customiser_DAL.Database {

    public class ArticleDAL {
        private readonly ApplicationDbContext _context;

        public ArticleDAL(ApplicationDbContext context) {
            _context = context;
        }

        public List<Ingredient> GetIngredientsByCategory(int categoryID) {
            try {
                return _context.Ingredient.FromSqlRaw("SELECT * FROM article WHERE C_ID = {0}", categoryID).ToList();
            } catch (Exception) {
                throw new ConnectionFailedException();
            }
        }

        public List<Product> GetProductsByCategory(int categoryID) {
            try {
                return _context.Product.FromSqlRaw("SELECT * FROM article WHERE C_ID = {0}", categoryID).ToList();
            } catch (Exception) {
                throw new ConnectionFailedException();
            }
        }

        public void UpdateIngredient(Ingredient ingredient) {
            _context.Update(ingredient);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product) {
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}