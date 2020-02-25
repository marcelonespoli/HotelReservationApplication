using HR.Domain.Core.Events;

namespace HR.Domain.Interfaces
{
    public interface IEventStore
    {
        void SaveEvent<T>(T @event) where T : Event;
    }
}
