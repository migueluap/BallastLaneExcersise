using System.Security.Claims;

namespace BallastLane.Domain.Interfaces;

public interface IUser
{
    string Name { get; }
    bool IsAuthenticated();
    IEnumerable<Claim> GetClaimsIdentity();
}