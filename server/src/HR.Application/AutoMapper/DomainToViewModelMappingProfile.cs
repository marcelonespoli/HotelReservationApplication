using AutoMapper;
using HR.Application.ViewModels;
using HR.Domain;

namespace HR.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Hotel, HotelViewModel>();
            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomBooked, RoomBookedViewModel>();
        }
    }
}
