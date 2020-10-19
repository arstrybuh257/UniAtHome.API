using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;

namespace Microsoft.AspNetCore.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    sealed class NoGuestAttribute : AuthorizeAttribute
    {
        public NoGuestAttribute() : base()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
