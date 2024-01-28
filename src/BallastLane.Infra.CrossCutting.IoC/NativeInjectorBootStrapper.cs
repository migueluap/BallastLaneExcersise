using BallastLane.Application.Interfaces;
using BallastLane.Application.Services;
using BallastLane.Domain.CommandHandlers;
using BallastLane.Domain.Commands;
using BallastLane.Domain.Core.Bus;
using BallastLane.Domain.Core.Events;
using BallastLane.Domain.Core.Notifications;
using BallastLane.Domain.EventHandlers;
using BallastLane.Domain.Events;
using BallastLane.Domain.Interfaces;
using BallastLane.Infra.CrossCutting.Bus;
using BallastLane.Infra.CrossCutting.Identity.Authorization;
using BallastLane.Infra.CrossCutting.Identity.Models;
using BallastLane.Infra.Data.Context;
using BallastLane.Infra.Data.EventSourcing;
using BallastLane.Infra.Data.Repository;
using BallastLane.Infra.Data.Repository.EventSourcing;
using BallastLane.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BallastLane.Infra.CrossCutting.IoC;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // ASP.NET Authorization Polices
        services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

        // Application
        services.AddScoped<ICustomerAppService, CustomerAppService>();

        // Domain - Events
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
        services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
        services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

        // Domain - Commands
        services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

        // Infra - Data
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<BallastLaneContext>();

        // Infra - Data EventSourcing
        services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
        services.AddScoped<IEventStore, SqlEventStore>();
        services.AddScoped<EventStoreSqlContext>();

        // Infra - Identity
        services.AddScoped<IUser, AspNetUser>();
    }
}