using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Domain.Rooms.Events
{
    public class RoomEventHandler :
        INotificationHandler<RoomCreatedEvent>,
        INotificationHandler<RoomBookedAddedEvent>
    {
        public Task Handle(RoomCreatedEvent message, CancellationToken cancellationToken)
        {
            // TODO: Run some action
            return Task.CompletedTask;
        }

        public Task Handle(RoomBookedAddedEvent message, CancellationToken cancellationToken)
        {
            // TODO: Run some action
            return Task.CompletedTask;
        }
    }
}
