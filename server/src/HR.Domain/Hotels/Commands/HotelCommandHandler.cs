using HR.Domain.Core.Notifications;
using HR.Domain.Handlers;
using HR.Domain.Hotels.Events;
using HR.Domain.Hotels.Repository;
using HR.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Domain.Hotels.Commands
{
    public class HotelCommandHandler : CommandHandler,
        IRequestHandler<CreateHotelCommand, bool>,
        IRequestHandler<UpdateHotelCommand, bool>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMediatorHandler _mediator;

        public HotelCommandHandler(
            IUnitOfWork uow, 
            IMediatorHandler mediator,
            IHotelRepository hotelRepository,
            INotificationHandler<DomainNotification> notifications) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _hotelRepository = hotelRepository;
        }

        public Task<bool> Handle(CreateHotelCommand message, CancellationToken cancellationToken)
        {
            var hotel = new Hotel(Guid.NewGuid(), message.Name, message.Address, message.City, message.Phone, message.Stars);

            if (!IsHotelValid(hotel))
                return Task.FromResult(false);

            _hotelRepository.Add(hotel);

            if (Commit())
            {
                _mediator.PublishEvent(new HotelCreatedEvent(message.Id, message.Name, message.Address, 
                    message.City, message.Phone, message.Stars));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateHotelCommand message, CancellationToken cancellationToken)
        {
            var hotel = new Hotel(message.Id, message.Name, message.Address, message.City, message.Phone, message.Stars);

            if (!IsHotelValid(hotel))
                return Task.FromResult(false);

            _hotelRepository.Update(hotel);

            if (Commit())
            {
                _mediator.PublishEvent(new HotelUpdatedEvent(message.Id, message.Name, message.Address,
                    message.City, message.Phone, message.Stars));
            }

            return Task.FromResult(true);
        }

        private bool IsHotelValid(Hotel hotel)
        {
            if (hotel.IsValid()) return true;

            NotifyValidationError(hotel.ValidationResult);
            return false;
        }
    }
}
