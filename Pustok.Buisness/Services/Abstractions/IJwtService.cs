using Pustok.Buisness.Dtos.TokenDtos;
using System.Security.Claims;

namespace Pustok.Buisness.Services.Abstractions
{
    public interface IJwtService
    {
        AccessTokenDto CreateAccessToken(List<Claim> claims);

    }
}
