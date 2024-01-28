using BallastLane.Domain.Core.Events;

namespace BallastLane.Domain.Events;

public class CustomerRemovedEvent : Event
{
    public CustomerRemovedEvent(Guid id)
    {
        Id = id;
        AggregateId = id;
    }

    public Guid Id { get; set; }
}
