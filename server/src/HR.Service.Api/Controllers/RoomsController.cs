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
    public class RoomsController : BaseController
    {
        private readonly IRoomAppService _roomAppService;

        public RoomsController(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            IRoomAppService roomAppService) : base(mediator, notifications)
        {
            _roomAppService = roomAppService;
        }

        [HttpGet]
        [Route("rooms")]
        public IEnumerable<RoomViewModel> Get()
        {
            return _roomAppService.GetAll();
        }

        [HttpGet]
        [Route("rooms/{id:guid}")]
        public RoomViewModel Get(Guid id)
        {
            return _roomAppService.GetById(id);
        }
        

        [HttpGet]
        [Route("rooms/hotel/{hotelId:guid}")]
        public IEnumerable<RoomViewModel> GetRoomsForHotel(Guid hotelId)
        {
            return _roomAppService.GetRoomsByHotelId(hotelId);
        }

        [HttpPost]
        [Route("rooms")]
        public IActionResult Post([FromBody] CreateRoomViewModel createRoomViewModel)
        {
            if (!IsModelStateValid())
            {
                return Response();
            }

            var roomCommand = _roomAppService.CreateRoom(createRoomViewModel);
            return Response(roomCommand);
        }

        [HttpGet]
        [Route("rooms/booked/{roomId:guid}")]
        public IEnumerable<RoomBookedViewModel> GetRoomsBookedForRoom(Guid roomId)
        {
            return _roomAppService.GetRoomsBookedByRoomId(roomId);
        }

        [HttpPost]
        [Route("rooms/booked")]
        public IActionResult PostRoomBooked([FromBody] AddRoomBookedViewModel addRoomBookedViewModel)
        {
            if (!IsModelStateValid())
            {
                return Response();
            }

            var roomBookedCommand = _roomAppService.AddRoomBooked(addRoomBookedViewModel);
            return Response(roomBookedCommand);
        }
    }
}