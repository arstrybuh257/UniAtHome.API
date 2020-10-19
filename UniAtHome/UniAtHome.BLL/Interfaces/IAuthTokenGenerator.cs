using System.Collections.Generic;
using System.Security.Claims;

namespace UniAtHome.BLL.Interfaces
{
    public interface IAuthTokenGenerator
    {
        string GenerateTokenForClaims(IEnumerable<Claim> userClaims);
    }
}
