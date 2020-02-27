using AutoMapper;
using HR.Application.ViewModels;
using HR.Domain.Hotels.Commands;
using HR.Domain.Rooms.Commands;

namespace HR.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateHotelViewModel, CreateHotelCommand>()
                .ConstructUsing(c => new CreateHotelCommand(
                    c.Name,
                    c.Address,
                    c.City,
                    c.Phone,
                    c.Stars));

            CreateMap<UpdateHotelViewModel, UpdateHotelCommand>()
                .ConstructUsing(c => new UpdateHotelCommand(
                    c.Id,
                    c.Name,
                    c.Address,
                    c.City,
                    c.Phone,
                    c.Stars));

            CreateMap<RoomViewModel, CreateRoomCommand>()
                    .ConvertUsing<RoomViewModelToCreateRoomCommand>();

            CreateMap<RoomBookedViewModel, AddRoomBookedCommand>()
                .ConstructUsing(c => new AddRoomBookedCommand(
                    c.RoomId,
                    c.Date));
        }
    }
}
