using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pustok.Buisness.Dtos.TokenDtos;
using Pustok.Buisness.Dtos.UserDtos;
using Pustok.Buisness.Exceptions;
using Pustok.Buisness.Services.Abstractions;
using Pustok.Core.Entities;
using Pustok.Core.Enums;
using System.Security.Claims;

namespace Pustok.Buisness.Services.Implementations
{
    public class AuthService(UserManager<AppUser> _userManager, IMapper _mapper, IJwtService _jwtService) : IAuthService
    {
        public async Task<ResultDto<AccessTokenDto>> LoginAsync(LoginDto loginDto)
        {

            var user = await _userManager.FindByNameAsync(loginDto.EmailOrUsername);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginDto.EmailOrUsername);

                if (user is null)
                {
                    throw new LoginException();
                }

            }

            var isTruePassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (isTruePassword is false)
                throw new LoginException();

            var roles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new()
            {
                new Claim("Username",user.UserName),
                new Claim("Email", user.Email),
                new Claim("Fullname", user.Fullname),
                new Claim("Role", roles.First())
            };

            var tokenResult = _jwtService.CreateAccessToken(claims);

            return new(tokenResult);

        }

        public async Task<ResultDto> RegisterAsync(RegisterDto dto)
        {
            var isExistEmail = await _userManager.Users.AnyAsync(x => x.Email!.ToLower() == dto.Email.ToLower());

            if (isExistEmail)
            {
                throw new AlreadyExistException("This mail is already exist");
            }

            var isExistUserName = await _userManager.Users.AnyAsync(x => x.UserName!.ToLower() == dto.Username.ToLower());

            if (isExistUserName)
                throw new AlreadyExistException("This username is already exist");

            var appUser = _mapper.Map<AppUser>(dto);

            var result = await _userManager.CreateAsync(appUser, dto.Password);

            if (!result.Succeeded)
            {
                string message = string.Join(',', result.Errors.Select(x => x.Description));

                throw new RegisterException(message);
            }

            await _userManager.AddToRoleAsync(appUser, IdentityRoles.Member.ToString());

            return new();

        }
    }
}
