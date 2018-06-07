using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiJwt.Interfaces;
using WebApiJwt.Interfaces.Repositories;
using WebApiJwt.Resources.Models;

namespace WebApiJwt.Core.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IUnitOfWork uof;

        public OrderRepository(ApplicationDbContext context, IUnitOfWork uof)
        {
            this.context = context;
            this.uof = uof;
        }

        public void Delete(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> Get()
        {
            return context.Order.ToList();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public Order Save(Order order)
        {
            context.Order.Add(order);
            uof.SaveChanges();

            return order;
        }

        public Order Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
