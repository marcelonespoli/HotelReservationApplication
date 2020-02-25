using System;

namespace HR.Domain.Hotels.Commands
{
    public class UpdateHotelCommand : BaseHotelCommand
    {
        public UpdateHotelCommand(Guid id, string name, string address, string city, string phone, int stars)
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
