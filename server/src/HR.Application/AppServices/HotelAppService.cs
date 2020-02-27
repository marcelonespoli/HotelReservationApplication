using AutoMapper;
using HR.Application.Interfaces;
using HR.Application.ViewModels;
using HR.Domain.Hotels.Commands;
using HR.Domain.Hotels.Repository;
using HR.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace HR.Application.AppServices
{
    public class HotelAppService : IHotelAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IHotelRepository _hotelRepository;

        public HotelAppService(
            IMapper mapper,
            IMediatorHandler mediatorHandler,
            IHotelRepository hotelRepository)
        {
            _mapper = mapper;
            _hotelRepository = hotelRepository;
            _mediatorHandler = mediatorHandler;
        }

        public IEnumerable<HotelViewModel> GetAll()
        {
            var hotels = _hotelRepository.GetAll();
            return _mapper.Map<IEnumerable<HotelViewModel>>(hotels);
        }

        public HotelViewModel GetById(Guid id)
        {
            var hotel = _hotelRepository.GetById(id);
            return _mapper.Map<HotelViewModel>(hotel);
        }

        public CreateHotelCommand CreateHotel(CreateHotelViewModel createHotelViewModel)
        {
            var hotel = _mapper.Map<CreateHotelCommand>(createHotelViewModel);

            _mediatorHandler.SendCommand(hotel);

            return hotel;
        }                

        public UpdateHotelCommand UpdateHotel(UpdateHotelViewModel updateHotelViewModel)
        {
            var hotel = _mapper.Map<UpdateHotelCommand>(updateHotelViewModel);

            _mediatorHandler.SendCommand(hotel);

            return hotel;
        }
    }
}
