using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Domain.Core.Base
{
    public class AggregateRoot<Tkey> : Entity<Tkey>, IAggregateRoot
    {
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
            //publish
            //1 => get IMeditR from HttpContext

            //2 => Global Class Utility => Event Publish 


            //
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        private List<IDomainEvent> _domainEvents;
    }
}