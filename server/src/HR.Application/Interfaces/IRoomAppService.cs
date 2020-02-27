using HR.Application.ViewModels;
using HR.Domain.Rooms.Commands;
using System;
using System.Collections.Generic;

namespace HR.Application.Interfaces
{
    public interface IRoomAppService
    {
        IEnumerable<RoomViewModel> GetAll();
        RoomViewModel GetById(Guid id);
        CreateRoomCommand CreateRoom(RoomViewModel roomViewModel);
        RoomBookedViewModel GetRoomBookedById(Guid id);
        IEnumerable<RoomBookedViewModel> GetRoomsBookedByRoomId(Guid roomId);
        AddRoomBookedCommand AddRoomBooked(RoomBookedViewModel roomBookedViewModel);
        IEnumerable<RoomViewModel> GetRoomsByHotelId(Guid hotelId);
        IEnumerable<RoomViewModel> GetRoomsAvailablePerPeriod(Guid hotelId, DateTime startDate, DateTime endDate);
    }
}
