﻿using Burger_Customiser_BLL;

namespace Burger_Customiser_DAL.Database {

    public class OrderDAL {
        private readonly ApplicationDbContext context;

        public OrderDAL(ApplicationDbContext context) {
            this.context = context;
        }

        public void AddOrder(Order order) {
            context.Add(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order) {
            context.Update(order);
            context.SaveChanges();
        }
    }
}