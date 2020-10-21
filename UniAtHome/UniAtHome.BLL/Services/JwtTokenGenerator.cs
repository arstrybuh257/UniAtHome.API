using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniAtHome.BLL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public sealed class JwtTokenGenerator : IAuthTokenGenerator
    {
        private readonly int tokenLifetimeMinutes;

        public TokenValidationParameters TokenValidationParameters { get; }

        public JwtTokenGenerator(IConfiguration configuration)
        {
            var fromAppsettings = GetAuthTokenSettings(configuration);
            TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = fromAppsettings.ValidateLifetime,
                ValidateIssuer = true,
                ValidIssuer = fromAppsettings.ValidIssuer,
                ValidateAudience = true,
                ValidAudience = fromAppsettings.ValidAudience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(fromAppsettings.SigningKey))
            };
            tokenLifetimeMinutes = fromAppsettings.TokenLifetimeMinutes;
        }

        public string GenerateTokenForClaims(IEnumerable<Claim> userClaims)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: TokenValidationParameters.ValidIssuer,
                    audience: TokenValidationParameters.ValidAudience,
                    notBefore: now,
                    claims: userClaims,
                    expires: now.Add(TimeSpan.FromMinutes(tokenLifetimeMinutes)),
                    signingCredentials: new SigningCredentials(
                        key: TokenValidationParameters.IssuerSigningKey, 
                        algorithm: SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private static AuthTokenSettings GetAuthTokenSettings(IConfiguration configuration)
        {
            var tokenOptionsFromAppsettings = new AuthTokenSettings();
            configuration.Bind("AuthenticationToken", tokenOptionsFromAppsettings);
            return tokenOptionsFromAppsettings;
        }

        private class AuthTokenSettings
        {
            public string ValidIssuer { get; set; }

            public string ValidAudience { get; set; }

            public string SigningKey { get; set; }

            public bool ValidateLifetime { get; set; }

            public int TokenLifetimeMinutes { get; set; }
        }
    }
}
