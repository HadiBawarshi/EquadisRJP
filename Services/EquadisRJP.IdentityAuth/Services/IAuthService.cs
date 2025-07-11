using EquadisRJP.IdentityAuth.Models.Dtos;
using EquadisRJP.IdentityAuth.Models.Responses;

namespace EquadisRJP.IdentityAuth.Services
{
    public interface IAuthService
    {
        Task<RegisterResponseDto> RegisterUserAsync(RegisterUserDto dto);
        Task<TokenResponseDto> GenerateTokenAsync(TokenRequestDto dto);
    }
}
