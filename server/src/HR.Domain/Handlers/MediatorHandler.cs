using HR.Domain.Core.Commands;
using HR.Domain.Core.Events;
using HR.Domain.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace HR.Domain.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IEventStore _eventStore;
        private readonly IMediator _mediator;

        public MediatorHandler(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public async Task SendCommand<T>(T command) where T : Command
        {
            await _mediator.Send(command);
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore.SaveEvent(@event);

            await _mediator.Publish(@event);
        }
    }
}
