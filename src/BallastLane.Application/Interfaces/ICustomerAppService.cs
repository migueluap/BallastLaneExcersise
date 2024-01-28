using BallastLane.Application.EventSourcedNormalizers;
using BallastLane.Application.ViewModels;

namespace BallastLane.Application.Interfaces;

public interface ICustomerAppService : IDisposable
{
    void Register(CustomerViewModel customerViewModel);
    IEnumerable<CustomerViewModel> GetAll();
    CustomerViewModel GetById(Guid id);
    void Update(CustomerViewModel customerViewModel);
    void Remove(Guid id);
    IList<CustomerHistoryData> GetAllHistory(Guid id);
}
