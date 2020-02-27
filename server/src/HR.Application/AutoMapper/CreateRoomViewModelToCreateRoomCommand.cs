using AutoMapper;
using HR.Application.ViewModels;
using HR.Domain.Rooms.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.Application.AutoMapper
{
    class CreateRoomViewModelToCreateRoomCommand : ITypeConverter<CreateRoomViewModel, CreateRoomCommand>
    {
        public CreateRoomCommand Convert(CreateRoomViewModel source, CreateRoomCommand destination, ResolutionContext context)
        {
            var roomId = Guid.NewGuid();
            var roomsBooked = new List<AddRoomBookedCommand>();

            if (source.RoomsBooked != null && source.RoomsBooked.Any())
            {
                foreach (var item in source.RoomsBooked)
                {
                    var roomBooked = new AddRoomBookedCommand(roomId, item.Date);
                    roomsBooked.Add(roomBooked);
                }
            }

            return new CreateRoomCommand(roomId, source.Name, source.HotelId, roomsBooked);
        }
    }
}
