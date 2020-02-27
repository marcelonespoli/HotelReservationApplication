using HR.Application.ViewModels;
using HR.Domain.Hotels.Commands;
using System;
using System.Collections.Generic;

namespace HR.Application.Interfaces
{
    public interface IHotelAppService
    {
        IEnumerable<HotelViewModel> GetAll();
        HotelViewModel GetById(Guid id);
        CreateHotelCommand CreateHotel(CreateHotelViewModel hotelViewModel);
        UpdateHotelCommand UpdateHotel(UpdateHotelViewModel hotelViewModel);
    }
}
