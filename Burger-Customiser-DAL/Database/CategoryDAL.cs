using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {

    public class CategoryDAL {
        private readonly ApplicationDbContext _context;

        public CategoryDAL(ApplicationDbContext context) {
            _context = context;
        }

        public Category GetCategoryById(int id) {
            try {
                return _context.Category.FromSqlRaw("SELECT * FROM category WHERE C_ID = {0}", id).ToList()[0];
            } catch (Exception) {
                throw new ConnectionFailedException();
            }
        }

        public List<Category> GetCategoriesByType(int typeId) {
            try {
                return _context.Category.FromSqlRaw("SELECT * FROM category WHERE type = {0}", typeId).ToList();
            } catch (Exception) {
                throw new ConnectionFailedException();
            }
        }
    }
}