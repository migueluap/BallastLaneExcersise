﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BallastLane.Application.EventSourcedNormalizers;
using BallastLane.Application.Interfaces;
using BallastLane.Application.ViewModels;
using BallastLane.Domain.Commands;
using BallastLane.Domain.Core.Bus;
using BallastLane.Domain.Interfaces;
using BallastLane.Infra.Data.Repository.EventSourcing;

namespace BallastLane.Application.Services;

public class CustomerAppService : ICustomerAppService
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IEventStoreRepository _eventStoreRepository;
    private readonly IMediatorHandler Bus;

    public CustomerAppService(IMapper mapper,
                              ICustomerRepository customerRepository,
                              IMediatorHandler bus,
                              IEventStoreRepository eventStoreRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        Bus = bus;
        _eventStoreRepository = eventStoreRepository;
    }

    public IEnumerable<CustomerViewModel> GetAll()
    {
        return _customerRepository.GetAll().ProjectTo<CustomerViewModel>(_mapper.ConfigurationProvider);
    }

    public CustomerViewModel GetById(Guid id)
    {
        return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
    }

    public void Register(CustomerViewModel customerViewModel)
    {
        var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
        Bus.SendCommand(registerCommand);
    }

    public void Update(CustomerViewModel customerViewModel)
    {
        var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
        Bus.SendCommand(updateCommand);
    }

    public void Remove(Guid id)
    {
        var removeCommand = new RemoveCustomerCommand(id);
        Bus.SendCommand(removeCommand);
    }

    public IList<CustomerHistoryData> GetAllHistory(Guid id)
    {
        return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
