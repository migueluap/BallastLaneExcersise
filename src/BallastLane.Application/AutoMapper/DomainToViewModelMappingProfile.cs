using AutoMapper;
using BallastLane.Application.ViewModels;
using BallastLane.Domain.Models;

namespace BallastLane.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Customer, CustomerViewModel>();
    }
}
