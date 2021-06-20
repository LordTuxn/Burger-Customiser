using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using Microsoft.Extensions.Logging;
using System;

namespace Burger_Customiser_DAL.Database {

    public class BurgerDAL {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext context;

        public BurgerDAL(ILogger<BurgerDAL> logger, ApplicationDbContext context) {
            _logger = logger;
            this.context = context;
        }

        public void AddBurger(Burger burger) {
            try {
                context.Add(burger);
                context.SaveChanges();
            } catch (Exception ex) {
                _logger.LogError(ex.StackTrace);
                throw new ConnectionFailedException();
            }
        }

        public void AddBurgerIngredient(BurgerIngredient burgerIngredient) {
            try {
                context.Add(burgerIngredient);
                context.SaveChanges();
            } catch (Exception ex) {
                _logger.LogError(ex.StackTrace);
                throw new ConnectionFailedException();
            }
        }
    }
}