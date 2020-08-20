using System.Collections.Generic;
using System.Security.Claims;

namespace Mamba.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        int GetUserId();
        string GetUserEmail();
        bool IsAutheticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
