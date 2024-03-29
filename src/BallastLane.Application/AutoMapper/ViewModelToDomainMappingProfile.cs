﻿using AutoMapper;
using BallastLane.Application.ViewModels;
using BallastLane.Domain.Commands;

namespace BallastLane.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
            .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
        CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
    }
}
