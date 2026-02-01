using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pustok.Buisness.Dtos.TokenDtos;
using Pustok.Buisness.Services.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pustok.Buisness.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptionDto _dto;
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dto = _configuration.GetSection("JwtOptions").Get<JwtOptionDto>() ?? new();
        }


        public AccessTokenDto CreateAccessToken(List<Claim> claims)
        {
            // Header
            JwtHeader jwtHeader = CreateJwtHeader();


            //Payload

            JwtPayload payload = new(_dto.Issuer, _dto.Audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(_dto.ExpireDate));

            JwtSecurityToken jwtSecurityToken = new(jwtHeader, payload);

            JwtSecurityTokenHandler handler = new();

            string token = handler.WriteToken(jwtSecurityToken);

            return new()
            {
                Token = token,
                ExpirationDate = DateTime.UtcNow.AddMinutes(_dto.ExpireDate),
            };
        }

        private JwtHeader CreateJwtHeader()
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_dto.SecretKey));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

            JwtHeader jwtHeader = new(signingCredentials);
            return jwtHeader;
        }
    }
}
