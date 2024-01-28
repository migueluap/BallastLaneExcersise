using BallastLane.Domain.Core.Events;

namespace BallastLane.Infra.Data.Repository.EventSourcing;

public interface IEventStoreRepository : IDisposable
{
    void Store(StoredEvent theEvent);
    IList<StoredEvent> All(Guid aggregateId);
}