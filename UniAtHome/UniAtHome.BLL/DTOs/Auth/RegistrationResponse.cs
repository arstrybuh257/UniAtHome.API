using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class RegistrationResponse : ErrorProneOperationResponse
    {
        public RegistrationResponse() : base()
        {
        }

        public RegistrationResponse(IEnumerable<IdentityError> errors) : base(errors)
        {
        }
    }
}
