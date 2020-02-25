using System;

namespace HR.Domain.Hotels.Events
{
    public class HotelCreatedEvent : BaseHotelEvent
    {
        public HotelCreatedEvent(Guid id, string name, string address, string city, string phone, int stars)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            Phone = phone;
            Stars = stars;
            AggregateId = id;
        }
    }
}
