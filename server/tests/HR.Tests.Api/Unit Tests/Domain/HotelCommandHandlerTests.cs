using AutoMapper;
using HR.Domain;
using HR.Domain.Core.Notifications;
using HR.Domain.Hotels.Commands;
using HR.Domain.Hotels.Events;
using HR.Domain.Hotels.Repository;
using HR.Domain.Interfaces;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HR.Tests.Api.Unit_Tests.Domain
{
    public class HotelCommandHandlerTests
    {
        public HotelCommandHandler hotelCommandHandler { get; set; }
        public Mock<IMapper> mockMapper { get; set; }
        public Mock<IUnitOfWork> mockUnitOfWork { get; set; }
        public Mock<IMediatorHandler> mockMediatorHandler { get; set; }
        public Mock<IHotelRepository> mockHotelRepository { get; set; }
        public Mock<DomainNotificationHandler> mockNotifications { get; set; }


        public HotelCommandHandlerTests()
        {
            mockMapper = new Mock<IMapper>();
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockMediatorHandler = new Mock<IMediatorHandler>();
            mockHotelRepository = new Mock<IHotelRepository>();
            mockNotifications = new Mock<DomainNotificationHandler>();

            hotelCommandHandler = new HotelCommandHandler(mockUnitOfWork.Object, mockMediatorHandler.Object,
                mockHotelRepository.Object, mockNotifications.Object);
        }

        // AAA => Arrange, Act, Assert
        [Fact(DisplayName = "Create hotel with success")]
        [Trait("Domain", "Hotel Command Handler")]
        public async Task HotelCommandHandler_HandleCreateHotelCommand_ReturnWithSuccess()
        {
            // Arrange
            var createHotelCommand = new CreateHotelCommand("Test hotel", "Street 5", "Dublin", "085 859 1133", 5);
            mockUnitOfWork.Setup(m => m.Commit()).Returns(true);

            // Act
            var result = await hotelCommandHandler.Handle(createHotelCommand, CancellationToken.None);

            // Assert
            mockHotelRepository.Verify(m => m.Add(It.IsAny<Hotel>()), Times.Once);
            mockMediatorHandler.Verify(m => m.PublishEvent(It.IsAny<HotelCreatedEvent>()), Times.Once);
            Assert.True(result);
        }

        [Fact(DisplayName = "Create hotel with NOT success")]
        [Trait("Domain", "Hotel Command Handler")]
        public async Task HotelCommandHandler_HandleCreateHotelCommand_ReturnWithNOTSuccess()
        {
            // Arrange
            var createHotelCommand = new CreateHotelCommand("", "", "Dublin", "085 859 1133", 8);
            mockUnitOfWork.Setup(m => m.Commit()).Returns(true);

            // Act
            var result = await hotelCommandHandler.Handle(createHotelCommand, CancellationToken.None);

            // Assert
            mockUnitOfWork.Verify(m => m.Commit(), Times.Never);
            mockHotelRepository.Verify(m => m.Add(It.IsAny<Hotel>()), Times.Never);
            mockMediatorHandler.Verify(m => m.PublishEvent(It.IsAny<HotelCreatedEvent>()), Times.Never);
            Assert.False(result);
        }

        [Fact(DisplayName = "Create hotel commit failed")]
        [Trait("Domain", "Hotel Command Handler")]
        public async Task HotelCommandHandler_HandleCreateHotelCommand_ReturnCommitFailed()
        {
            // Arrange
            var createHotelCommand = new CreateHotelCommand("Test hotel", "Street 5", "Dublin", "085 859 1133", 5);
            mockUnitOfWork.Setup(m => m.Commit()).Returns(false);

            // Act
            var result = await hotelCommandHandler.Handle(createHotelCommand, CancellationToken.None);

            // Assert
            mockHotelRepository.Verify(m => m.Add(It.IsAny<Hotel>()), Times.Once);
            mockMediatorHandler.Verify(m => m.PublishEvent(It.IsAny<HotelCreatedEvent>()), Times.Never);
            Assert.True(result);
        }
    }
}
