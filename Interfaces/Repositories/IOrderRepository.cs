using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiJwt.Resources.Models;

namespace WebApiJwt.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        List<Order> Get();
        Order Get(int id);
        Order Save(Order order);
        Order Update(Order order);
        void Delete(Order order);
    }
}
