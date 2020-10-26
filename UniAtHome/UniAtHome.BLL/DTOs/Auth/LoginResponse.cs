using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class LoginResponse : ErrorProneOperationResponse
    {
        public LoginResponse(IEnumerable<OperationError> errors = null) : base(errors)
        {
        }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
