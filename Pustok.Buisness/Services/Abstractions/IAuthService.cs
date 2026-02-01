using Pustok.Buisness.Dtos.UserDtos;

namespace Pustok.Buisness.Services.Abstractions
{
    public interface IAuthService
    {
        Task<ResultDto> RegisterAsync(RegisterDto dto);

    }
}
