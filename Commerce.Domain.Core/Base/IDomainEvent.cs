using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Commerce.Domain.Core.Base
{
     public interface IDomainEvent : INotification 
    {
    }

    

   

    public abstract record class DomainEvent : IDomainEvent
    {
        public DateTime CreatedAt { get; init; }

        public DomainEvent()
        {
            CreatedAt = DateTime.Now;
        }
    }

    
}