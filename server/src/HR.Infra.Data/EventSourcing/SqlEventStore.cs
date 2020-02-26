using HR.Domain.Core.Events;
using HR.Domain.Interfaces;
using HR.Infra.Data.Repository.EventSourcing;
using Newtonsoft.Json;

namespace HR.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void SaveEvent<T>(T @event) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(@event);

            var storedEvent = new StoredEvent(
                @event,
                serializedData);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
