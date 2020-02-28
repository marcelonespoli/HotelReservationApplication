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

            CreateMap<CreateRoomViewModel, CreateRoomCommand>()
                    .ConvertUsing<CreateRoomViewModelToCreateRoomCommand>();

            CreateMap<AddRoomBookedViewModel, AddRoomBookedCommand>()
                .ConstructUsing(c => new AddRoomBookedCommand(
                    c.Date));
        }
    }
}
