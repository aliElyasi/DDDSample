using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Domain.Core.UserBoundedContext.Event;
using MediatR;

namespace Commerce.Application.eventHandler
{
    public class AddUserEventHandler: INotificationHandler<AddUserEvent>
    {
        public AddUserEventHandler()
        {
            
        }
        public Task Handle(AddUserEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("user added");

            
            return Task.CompletedTask;
        }

        
    }
}