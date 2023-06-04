using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using Commerce.Domain.Core.UserBoundedContext;
using MediatR;
using Commerce.Infrastructure.Database.Extentions;

namespace Commerce.Infrastructure.Database.Context
{
    public class CommerceContext : DbContext
    {
        private readonly IMediator _mediator;

        public CommerceContext(DbContextOptions<CommerceContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommerceContext).Assembly);
        }
        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}