using HR.Domain.Core.Notifications;
using HR.Domain.Handlers;
using HR.Domain.Hotels.Repository;
using HR.Domain.Interfaces;
using HR.Domain.Rooms.Events;
using HR.Domain.Rooms.Repository;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Domain.Rooms.Commands
{
    public class RoomCommandHandler : CommandHandler,
        IRequestHandler<CreateRoomCommand, bool>,
        IRequestHandler<AddRoomBookedCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IMediatorHandler _mediator;

        public RoomCommandHandler(
            IUnitOfWork uow, 
            IMediatorHandler mediator,
            IRoomRepository roomRepository,
            IHotelRepository hotelRepository,
            INotificationHandler<DomainNotification> notifications) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
        }

        public Task<bool> Handle(CreateRoomCommand message, CancellationToken cancellationToken)
        {
            var room = new Room(message.Id, message.Name, message.HotelId);

            if (message.RoomsBooked != null && message.RoomsBooked.Any())
            {
                foreach (var booked in message.RoomsBooked)
                {
                    var roomBooked = new RoomBooked(booked.Id, room.Id, booked.Date);
                    room.RoomsBooked.Add(roomBooked);
                }
            }

            if (!IsRoomValid(room, message.MessageType))
                return Task.FromResult(false);

            _roomRepository.Add(room);

            if (Commit())
            {
                var roomsBookedAdd = new List<RoomBookedAddedEvent>();
                foreach (var booked in room.RoomsBooked)
                {
                    var roomBooked = new RoomBookedAddedEvent(booked.Id, booked.RoomId, booked.Date);
                    roomsBookedAdd.Add(roomBooked);
                }
                _mediator.PublishEvent(new RoomCreatedEvent(room.Id, room.Name, room.HotelId, roomsBookedAdd));
            }

            return Task.FromResult(true);

        }

        public Task<bool> Handle(AddRoomBookedCommand message, CancellationToken cancellationToken)
        {
            var roomBooked = new RoomBooked(message.Id, message.RoomId, message.Date);

            if (!IsRoomBookedValid(roomBooked, message.MessageType))
                return Task.FromResult(false);

            _roomRepository.AddRoomBooked(roomBooked);

            if (Commit())
            {
                _mediator.PublishEvent(new RoomBookedAddedEvent(message.Id, message.RoomId, message.Date));
            }

            return Task.FromResult(true);
        }

        private bool IsRoomValid(Room room, string messageType)
        {
            var hotel = _hotelRepository.GetById(room.HotelId);
            
            if (hotel == null)
            {
                _mediator.PublishEvent(new DomainNotification(messageType, "Hotel not found"));
                return false;
            }

            if (room.IsValid()) return true;

            NotifyValidationError(room.ValidationResult);
            return false;
        }

        private bool IsRoomBookedValid(RoomBooked roomBooked, string messageType)
        {
            var room = _roomRepository.GetById(roomBooked.RoomId);

            if (room == null)
            {
                _mediator.PublishEvent(new DomainNotification(messageType, "Room not found"));
                return false;
            }

            if (roomBooked.IsValid()) return true;

            NotifyValidationError(roomBooked.ValidationResult);
            return false;
        }
    }
}
