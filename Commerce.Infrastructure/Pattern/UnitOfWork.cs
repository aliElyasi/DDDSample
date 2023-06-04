using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Infrastructure.Database.Context;

namespace Commerce.Infrastructure.Pattern
{
    public class UnitOfWork : IUnitOfWork
    {
         private readonly CommerceContext context;

        public UnitOfWork(CommerceContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task SaveChanges()
        {
            await context.CommitAsync();
        }
    }
}