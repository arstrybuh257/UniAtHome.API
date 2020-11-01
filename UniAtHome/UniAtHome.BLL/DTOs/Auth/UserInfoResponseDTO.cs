using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class UserInfoResponseDTO : ErrorProneOperationResponse
    {
        public UserInfoResponseDTO()
        {
        }

        public UserInfoResponseDTO(string error) : base(error)
        {
        }

        public UserInfoResponseDTO(IEnumerable<OperationError> errors) : base(errors)
        {
        }

        public UserInfoResponseDTO(IEnumerable<IdentityError> errors) : base(errors)
        {
        }

        public string Email { get; set; }

        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
