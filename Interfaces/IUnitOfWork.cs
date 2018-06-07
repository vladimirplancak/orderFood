using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJwt.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
