using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiJwt.Core.Models;
using WebApiJwt.Interfaces;
using WebApiJwt.Interfaces.Repositories;

namespace WebApiJwt.Core.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IUnitOfWork _uof;

        public OrderRepository(ApplicationDbContext context, IUnitOfWork uof)
        {
            this.context = context;
            _uof = uof;
        }

        public void Delete(Order order)
        {
            context.Remove(order);
        }

        public IQueryable<Order> Get(bool includeDetails = false)
        {
            if (includeDetails)
            {
                return context.Order.Include(it => it.ApplicationUser);
            }
            else
            {
                return context.Order;
            }
            
        }

        public Order Get(int id, bool includeDetails = false)
        {
            if (includeDetails)
            {
                return context.Order.Include(it => it.ApplicationUser).FirstOrDefault(it => it.Id == id);
            }

            return context.Order.FirstOrDefault(it => it.Id == id);
        }

        public Order Save(Order order)
        {
            context.Order.Add(order);
            _uof.SaveChanges();

            return order;
        }
    }
}
