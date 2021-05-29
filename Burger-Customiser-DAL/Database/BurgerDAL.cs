using Burger_Customiser_BLL;

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
    }
}
