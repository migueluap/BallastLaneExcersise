namespace BallastLane.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    bool Commit();
}
