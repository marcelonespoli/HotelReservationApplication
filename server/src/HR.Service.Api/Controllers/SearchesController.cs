using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Application.Interfaces;
using HR.Application.ViewModels;
using HR.Domain.Core.Notifications;
using HR.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Service.Api.Controllers
{
    [Route("v1")]
    [ApiController]
    public class SearchesController : BaseController
    {
        private readonly IRoomAppService _roomAppService;

        public SearchesController(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            IRoomAppService roomAppService) : base(mediator, notifications)
        {
            _roomAppService = roomAppService;
        }

        [HttpGet]
        [Route("searches/available-rooms/{hotelId:guid}")]
        public IEnumerable<RoomViewModel> Get(Guid hotelId, DateTime startDate, DateTime endDate)
        {
            return _roomAppService.GetRoomsAvailablePerPeriod(hotelId, startDate, endDate);
        }
    }
}