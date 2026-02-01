using Azure.Core;
using Pustok.Buisness.Dtos.TokenDtos;
using Pustok.Buisness.Dtos.UserDtos;

namespace Pustok.Buisness.Services.Abstractions
{
    public interface IAuthService
    {
        Task<ResultDto> RegisterAsync(RegisterDto dto);
        Task<ResultDto<AccessTokenDto>> LoginAsync(LoginDto loginDto);

    }
}
