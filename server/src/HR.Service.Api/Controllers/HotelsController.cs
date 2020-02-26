using HR.Application.Interfaces;
using HR.Application.ViewModels;
using HR.Domain.Core.Notifications;
using HR.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HR.Service.Api.Controllers
{
    [Route("v1")]
    [ApiController]
    public class HotelsController : BaseController
    {
        private readonly IHotelAppService _hotelAppService;

        public HotelsController(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            IHotelAppService hotelAppService) : base(mediator, notifications)
        {
            _hotelAppService = hotelAppService;
        }

        [HttpGet]
        [Route("hotels")]
        public IEnumerable<HotelViewModel> Get()
        {
            return _hotelAppService.GetAll();
        }

        [HttpGet]
        [Route("hotels/{id:guid}")]
        public HotelViewModel Get(Guid id)
        {
            return _hotelAppService.GetById(id);
        }

        [HttpPost]
        [Route("hotels")]
        public IActionResult Post([FromBody] HotelViewModel hotelViewModel)
        {
            if (!IsModelStateValid())
            {
                return Response();
            }

            var hotelCommand = _hotelAppService.CreateHotel(hotelViewModel);
            return Response(hotelCommand);
        }

        [HttpPut]
        [Route("hotels")]
        public IActionResult Put([FromBody] HotelViewModel hotelViewModel)
        {
            if (!IsModelStateValid())
            {
                return Response();
            }

            var taskCommand = _hotelAppService.UpdateHotel(hotelViewModel);
            return Response(taskCommand);
        }
    }
}