using BallastLane.Domain.Core.Commands;
using BallastLane.Domain.Core.Events;

namespace BallastLane.Domain.Core.Bus;

public interface IMediatorHandler
{
    Task SendCommand<T>(T command) where T : Command;
    Task RaiseEvent<T>(T @event) where T : Event;
}