using FluentValidation;
using HR.Domain.Constants;
using HR.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace HR.Domain
{
    public class Hotel : Entity<Hotel>
    {
        public Hotel(Guid id, string name, string address, string city, string phone, int stars)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            Phone = phone;
            Stars = stars;

            Rooms = new List<Room>();
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Phone { get; private set; }
        public int Stars { get; private set; }


        // EF Property Navegation
        public virtual ICollection<Room> Rooms { get; set; }

        // EF Constructor
        protected Hotel() { }


        public override bool IsValid()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage(ValidationMessagesHotel.Error_Name_NotEmpty)
                .Length(2, 250).WithMessage(ValidationMessagesHotel.Error_Name_Length);

            RuleFor(r => r.Address)
                .NotEmpty().WithMessage(ValidationMessagesHotel.Error_Address_NotEmpty)
                .Length(2, 350).WithMessage(ValidationMessagesHotel.Error_Address_Length);

            RuleFor(r => r.City)
                .NotEmpty().WithMessage(ValidationMessagesHotel.Error_City_NotEmpty)
                .Length(2, 150).WithMessage(ValidationMessagesHotel.Error_City_Length);

            RuleFor(r => r.Phone)
                .NotEmpty().WithMessage(ValidationMessagesHotel.Error_Phone_NotEmpty)
                .Length(8, 15).WithMessage(ValidationMessagesHotel.Error_Phone_Length);

            RuleFor(r => r.Stars)
                .LessThanOrEqualTo(5).WithMessage(ValidationMessagesHotel.Error_Phone_NotEmpty)
                .GreaterThanOrEqualTo(0).WithMessage(ValidationMessagesHotel.Error_Stars_Length);

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
