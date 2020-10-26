using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRefreshResponse : ErrorProneOperationResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public TokenRefreshResponse(string error)
            : base(new[] { new OperationError(error) })
        {
        }

        public TokenRefreshResponse(IEnumerable<OperationError> errors = null) : base(errors)
        {
        }
    }
}
