using AutoMapper;
using HR.Application.Interfaces;
using HR.Application.ViewModels;
using HR.Domain.Interfaces;
using HR.Domain.Rooms.Commands;
using HR.Domain.Rooms.Repository;
using System;
using System.Collections.Generic;

namespace HR.Application.AppServices
{
    public class RoomAppService : IRoomAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IRoomRepository _roomRepository;

        public RoomAppService(
            IMapper mapper,
            IMediatorHandler mediatorHandler,
            IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            _mediatorHandler = mediatorHandler;
        }

        public IEnumerable<RoomViewModel> GetAll()
        {
            var rooms = _roomRepository.GetAll();
            return _mapper.Map<IEnumerable<RoomViewModel>>(rooms);
        }

        public RoomViewModel GetById(Guid id)
        {
            var room = _roomRepository.GetById(id);
            return _mapper.Map<RoomViewModel>(room);
        }

        public CreateRoomCommand CreateRoom(RoomViewModel roomViewModel)
        {
            var room = _mapper.Map<CreateRoomCommand>(roomViewModel);

            _mediatorHandler.SendCommand(room);

            return room;
        }

        public RoomBookedViewModel GetRoomBookedById(Guid id)
        {
            var roomBooked = _roomRepository.GetRoomBookedById(id);
            return _mapper.Map<RoomBookedViewModel>(roomBooked);
        }

        public IEnumerable<RoomBookedViewModel> GetRoomsBookedByRoomId(Guid roomId)
        {
            var roomsBooked = _roomRepository.GetRoomsBookedByRoomId(roomId);
            return _mapper.Map<IEnumerable<RoomBookedViewModel>>(roomsBooked);
        }

        public AddRoomBookedCommand AddRoomBooked(RoomBookedViewModel roomBookedViewModel)
        {
            var roomBooked = _mapper.Map<AddRoomBookedCommand>(roomBookedViewModel);

            _mediatorHandler.SendCommand(roomBooked);

            return roomBooked;
        }

        public IEnumerable<RoomViewModel> GetRoomsByHotelId(Guid hotelId)
        {
            var rooms = _roomRepository.GetRoomsByHotelId(hotelId);
            return _mapper.Map<IEnumerable<RoomViewModel>>(rooms);
        }

        public IEnumerable<RoomViewModel> GetRoomsAvailablePerPeriod(Guid hotelId, DateTime startDate, DateTime endDate)
        {
            var rooms = _roomRepository.GetRoomsAvailablePerPeriod(hotelId, startDate, endDate);
            return _mapper.Map<IEnumerable<RoomViewModel>>(rooms);
        }
    }
}
