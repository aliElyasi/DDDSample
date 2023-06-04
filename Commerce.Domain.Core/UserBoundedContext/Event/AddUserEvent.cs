using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.Base;

namespace Commerce.Domain.Core.UserBoundedContext.Event
{
    public record class AddUserEvent : DomainEvent
    {
        public Guid Id { get; set; }
        public AddUserEvent(User user)
        {
          
            Id=user.Id;
        }

    }
}