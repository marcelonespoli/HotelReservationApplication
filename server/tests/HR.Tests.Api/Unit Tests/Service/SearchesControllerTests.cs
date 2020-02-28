using HR.Application.Interfaces;
using HR.Application.ViewModels;
using HR.Domain.Core.Notifications;
using HR.Domain.Interfaces;
using HR.Service.Api.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HR.Tests.Api.Unit_Tests.Service
{
    public class SearchesControllerTests
    {
        public SearchesController searchesController { get; set; }
        public Mock<IRoomAppService> roomAppService { get; set; }
        public Mock<IMediatorHandler> mediator { get; set; }
        public Mock<DomainNotificationHandler> notifications { get; set; }

        public SearchesControllerTests()
        {
            roomAppService = new Mock<IRoomAppService>();
            mediator = new Mock<IMediatorHandler>();
            notifications = new Mock<DomainNotificationHandler>();

            searchesController = new SearchesController(mediator.Object, notifications.Object, roomAppService.Object);
        }

        // AAA => Arrange, Act, Assert
        [Fact(DisplayName = "Get available rooms for Hotel and per period")]
        [Trait("Reports", "Searches Controller")]
        public void SearchesController_GetAvailableRooms_ReturnWithSuccess()
        {
            // Arrange
            var rooms = new List<RoomViewModel>();
            roomAppService.Setup(m => m.GetRoomsAvailablePerPeriod(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(rooms);
            
            // Act
            var result = searchesController.Get(Guid.NewGuid(), DateTime.Today, DateTime.Today.AddDays(5));

            // Assert
            roomAppService.Verify(m => m.GetRoomsAvailablePerPeriod(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
            Assert.IsType<List<RoomViewModel>>(result);
        }
    }
}
