using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiJwt.Resources.Models;

namespace WebApiJwt.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        IQueryable<Order> Get(bool includeDetails = false);
        Order Get(int id, bool includeDetails = false);
        Order Save(Order order);
        void Delete(Order order);
    }
}
