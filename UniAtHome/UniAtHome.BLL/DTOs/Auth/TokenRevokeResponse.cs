using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRevokeResponse : ErrorProneOperationResponse
    {
        public TokenRevokeResponse(string error)
             : base(error)
        {

        }

        public TokenRevokeResponse(IEnumerable<OperationError> errors = null) : base(errors)
        {
        }
    }
}
