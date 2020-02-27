using System;

namespace HR.Domain.Hotels.Commands
{
    public class CreateHotelCommand : BaseHotelCommand
    {
        public CreateHotelCommand(string name, string address, string city, string phone, int stars)
        {
            var id = Guid.NewGuid();

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
