using FluentValidation;
using HR.Domain.Constants;
using HR.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace HR.Domain
{
    public class Room : Entity<Room>
    {
        public Room(Guid id, string name, Guid hotelId)
        {
            Id = id;
            Name = name;
            HotelId = hotelId;

            RoomsBooked = new List<RoomBooked>();
        }

        public string Name { get; private set; }
        public Guid HotelId { get; private set; }


        // EF Property Navegation
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<RoomBooked> RoomsBooked { get; set; }

        // EF Constructor
        protected Room() { }


        public override bool IsValid()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage(ValidationMessagesRoom.Error_Name_NoEmpity)
                .Length(2, 150).WithMessage(ValidationMessagesRoom.Error_Name_Length);

            RuleFor(r => r.HotelId)
                .NotNull().WithMessage(ValidationMessagesRoom.Error_HotelId_NullOrEmpty)
                .NotEmpty().WithMessage(ValidationMessagesRoom.Error_HotelId_NullOrEmpty);

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
