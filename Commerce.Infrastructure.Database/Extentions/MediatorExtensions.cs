using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.Base;
using Commerce.Infrastructure.Database.Context;
using MediatR;

namespace Commerce.Infrastructure.Database.Extentions
{
 internal static class MediatorExtensions
{
    public static async Task DispatchEventsAsync(this IMediator mediator, CommerceContext context) 
    {
        var aggregateRoots = context.ChangeTracker
            .Entries<IAggregateRoot>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        var domainEvents = aggregateRoots
            .SelectMany(x => x.DomainEvents)
            .ToList();

        await mediator.DispatchDomainEventsAsync(domainEvents);

        ClearDomainEvents(aggregateRoots);
    }

    private static async Task DispatchDomainEventsAsync(this IMediator mediator, List<IDomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }

    private static void ClearDomainEvents(List<IAggregateRoot> aggregateRoots)
    {
        aggregateRoots.ForEach(aggregate => aggregate.ClearDomainEvents());
    }
}
}