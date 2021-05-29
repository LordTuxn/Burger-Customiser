using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Burger_Customiser_DAL.Database {
    public class BurgerDAL {

        private readonly ApplicationDBContext context;

        public BurgerDAL(ApplicationDBContext context) {
            this.context = context;
        }

        public void AddBurger(Burger burger) {
            context.Add(burger);
            context.SaveChanges();
        }

        public void UpdateBurger(Burger burger) {
            context.Update(burger);
            context.SaveChanges();
        }

        public List<BurgerIngredient> GetBurgerIngredients(Burger burger) {
            //return burger.BurgerIngredients;
            return context.BurgerIngredients.FromSqlRaw($@"SELECT * FROM burger_has_ingredients WHERE B_ID = {burger.ID}").ToList();
        }

        public void AddBurgerIngredient(BurgerIngredient burgerIngredient) {
            context.Add(burgerIngredient);
            context.SaveChanges();
        }

        public void UpdateBurgerIngredient(BurgerIngredient burgerIngredient) {
            context.Update(burgerIngredient);
            context.SaveChanges();
        }

        public void RemoveBurgerIngredient(BurgerIngredient burgerIngredient) {
            context.Remove(burgerIngredient);
            context.SaveChanges();
        }
    }
}
