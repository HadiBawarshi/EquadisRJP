using EquadisRJP.Application.ExternalServices;
using EquadisRJP.IdentityAuth.Public.Dtos;
using EquadisRJP.IdentityAuth.Public.Responses;
using EquadisRJP.Infrastructure.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace EquadisRJP.Infrastructure.Repositories
{
    public sealed class IdentityAuthClient : IIdentityAuthClient
    {
        private readonly ILogger<IdentityAuthClient> _logger;
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public IdentityAuthClient(ILogger<IdentityAuthClient> logger, HttpClient http, IConfiguration config)
        {
            _logger = logger;
            _http = http;
            _config = config;
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterUserDto dto, CancellationToken ct = default)
        {
            _logger.LogInformation("Registering Identity user {User}", dto.Username);

            var resp = await _http.PostAsJsonAsync(IdentityRoutes.Register, dto, ct);

            if (!resp.IsSuccessStatusCode)
            {
                _logger.LogWarning("IdentityAuth returned {Status}", resp.StatusCode);

                return new RegisterResponseDto(false, string.Empty);
            }

            var data = await resp.Content.ReadFromJsonAsync<RegisterResponseDto>(cancellationToken: ct)
                       ?? new(false, string.Empty);

            _logger.LogInformation("IdentityAuth registration success={Success} UserId={UserId}", data.Success, data.UserId);
            return data;
        }
    }
}
