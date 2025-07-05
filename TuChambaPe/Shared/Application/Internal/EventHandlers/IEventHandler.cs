using TuChambaPe.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace TuChambaPe.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}