using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class LoginResponse : ErrorProneOperationResponse
    {
        public LoginResponse()
        {
        }

        public LoginResponse(string error) : base(error)
        {
        }

        public LoginResponse(IEnumerable<OperationError> errors) : base(errors)
        {
        }

        public LoginResponse(IEnumerable<IdentityError> errors) : base(errors)
        {
        }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public string Email { get; set; }
    }
}
