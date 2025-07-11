using EquadisRJP.IdentityAuth.Public.Dtos;
using EquadisRJP.IdentityAuth.Public.Responses;

namespace EquadisRJP.Application.ExternalServices
{
    public interface IIdentityAuthClient
    {
        Task<RegisterResponseDto> RegisterAsync(RegisterUserDto dto, CancellationToken ct = default);

    }
}
