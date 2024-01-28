using BallastLane.Domain.Models;

namespace BallastLane.Domain.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Customer GetByEmail(string email);
}
