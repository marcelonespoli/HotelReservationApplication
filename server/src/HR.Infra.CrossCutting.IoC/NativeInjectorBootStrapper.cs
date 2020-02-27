using HR.Application.AppServices;
using HR.Application.Interfaces;
using HR.Domain.Core.Notifications;
using HR.Domain.Handlers;
using HR.Domain.Hotels.Commands;
using HR.Domain.Hotels.Events;
using HR.Domain.Hotels.Repository;
using HR.Domain.Interfaces;
using HR.Domain.Rooms.Commands;
using HR.Domain.Rooms.Events;
using HR.Domain.Rooms.Repository;
using HR.Infra.CrossCutting.AspNetFilters;
using HR.Infra.Data.Context;
using HR.Infra.Data.EventSourcing;
using HR.Infra.Data.Repository;
using HR.Infra.Data.Repository.EventSourcing;
using HR.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Application
            services.AddScoped<IHotelAppService, HotelAppService>();
            services.AddScoped<IRoomAppService, RoomAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateHotelCommand, bool>, HotelCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateHotelCommand, bool>, HotelCommandHandler>();
            services.AddScoped<IRequestHandler<CreateRoomCommand, bool>, RoomCommandHandler>();
            services.AddScoped<IRequestHandler<AddRoomBookedCommand, bool>, RoomCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<HotelCreatedEvent>, HotelEventHandler>();
            services.AddScoped<INotificationHandler<HotelUpdatedEvent>, HotelEventHandler>();
            services.AddScoped<INotificationHandler<RoomCreatedEvent>, RoomEventHandler>();
            services.AddScoped<INotificationHandler<RoomBookedAddedEvent>, RoomEventHandler>();

            // Infra - Data
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<HotelContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();

            // Infra - Filtros
            services.AddScoped<GlobalExceptionHandlingFilter>();
        }
    }
}
