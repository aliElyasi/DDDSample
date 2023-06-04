using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Infrastructure.Pattern
{
    public interface IUnitOfWork:IDisposable
    {
                Task SaveChanges();

        
    }
}