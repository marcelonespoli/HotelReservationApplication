using FluentValidation;
using HR.Domain.Constants;
using HR.Domain.Core.Models;
using System;

namespace HR.Domain
{
    public class RoomBooked : Entity<RoomBooked>
    {
        public RoomBooked(Guid id, Guid roomId, DateTime date)
        {
            Id = id;
            RoomId = roomId;
            Date = date;
        }

        public Guid RoomId { get; private set; }
        public DateTime Date { get; private set; }


        // EF Property Navegation
        public virtual Room Room { get; set; }

        // EF Constructor
        protected RoomBooked() { }


        public override bool IsValid()
        {
            RuleFor(r => r.RoomId)
               .NotNull().WithMessage(ValidationMessagesRoomBooked.Error_RoomId_NullOrEmpty)
               .NotEmpty().WithMessage(ValidationMessagesRoomBooked.Error_RoomId_NullOrEmpty);

            RuleFor(r => r.Date)
               .NotNull().WithMessage(ValidationMessagesRoomBooked.Error_Date_Null)
               .GreaterThanOrEqualTo(DateTime.Today).WithMessage(ValidationMessagesRoomBooked.Error_Date_GreaterThanOrEqualToday);

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
