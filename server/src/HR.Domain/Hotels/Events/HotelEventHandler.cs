using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Domain.Hotels.Events
{
    public class HotelEventHandler :
        INotificationHandler<HotelCreatedEvent>,
        INotificationHandler<HotelUpdatedEvent>
    {
        public Task Handle(HotelCreatedEvent message, CancellationToken cancellationToken)
        {
            // TODO: Run some action
            return Task.CompletedTask;
        }

        public Task Handle(HotelUpdatedEvent message, CancellationToken cancellationToken)
        {
            // TODO: Run some action
            return Task.CompletedTask;
        }
    }
}
