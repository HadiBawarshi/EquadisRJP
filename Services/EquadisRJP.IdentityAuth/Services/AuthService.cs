using EquadisRJP.IdentityAuth.Constants;
using EquadisRJP.IdentityAuth.Data;
using EquadisRJP.IdentityAuth.Models.Dtos;
using EquadisRJP.IdentityAuth.Models.Responses;
using EquadisRJP.IdentityAuth.Public.Dtos;
using EquadisRJP.IdentityAuth.Public.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EquadisRJP.IdentityAuth.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly List<AuthClientModel> _clients;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration config, IOptions<List<AuthClientModel>> clients, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _config = config;
            _clients = clients.Value;
            _roleManager = roleManager;
        }

        public async Task<TokenResponseDto> GenerateTokenAsync(TokenRequestDto dto)
        {
            var client = ValidateClient(dto);

            if (client == null)
                return new TokenResponseDto
                {
                    Success = false,
                    Message = "Invalid client credentials or grant type"
                };

            var claims = new List<Claim>
                        {
                            new Claim(IdentityAuthConstants.ClaimClientId, dto.ClientId),
                            new Claim(IdentityAuthConstants.ClaimScope, string.Join(" ", client.AllowedScopes))
                        };

            if (dto.GrantType == IdentityAuthConstants.PasswordGrantType)
            {
                var user = await ValidateUserAsync(dto.Username, dto.Password);

                if (user == null)
                    return new TokenResponseDto
                    {
                        Success = false,
                        Message = "Invalid username or password"
                    };

                claims.AddRange(await BuildUserClaimsAsync(user));
            }

            var token = GenerateJwt(claims);

            return new TokenResponseDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = (int)(token.ValidTo - DateTime.UtcNow).TotalSeconds,
                Success = true,
                Message = string.Empty,
            };
        }

        public async Task<RegisterResponseDto> RegisterUserAsync(RegisterUserDto dto)
        {

            if (string.IsNullOrEmpty(dto.Role))
                return new RegisterResponseDto(false, string.Empty, "Role is required");

            //throw new ApplicationException("Role is required");




            if (!await _roleManager.RoleExistsAsync(dto.Role))
                return new RegisterResponseDto(false, string.Empty, $"Unexpected role: {dto.Role}");

            //throw new ApplicationException("UnExpected role");

            var user = new ApplicationUser { UserName = dto.Username, Email = dto.Email, PhoneNumber = dto.PhoneNumber, Name = dto.Name };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var message = string.Join("; ", result.Errors.Select(e => e.Description));
                return new RegisterResponseDto(false, string.Empty, message);
            }
            //throw new ApplicationException(string.Join("; ", result.Errors.Select(e => e.Description)));

            await _userManager.AddToRoleAsync(user, dto.Role);

            return new RegisterResponseDto(true, user.Id, "User created successfully");
        }


        #region Private Methods


        private AuthClientModel? ValidateClient(TokenRequestDto dto)
        {
            var client = _clients.FirstOrDefault(c =>
                c.ClientId == dto.ClientId &&
                c.ClientSecret == dto.ClientSecret &&
                c.AllowedGrantTypes.Contains(dto.GrantType));

            if (client == null)
                //throw new UnauthorizedAccessException("Invalid client credentials or grant type");
                return null;

            return client;
        }
        private async Task<ApplicationUser?> ValidateUserAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
                //throw new UnauthorizedAccessException("Invalid username or password");
                return null;


            return user;
        }

        private async Task<List<Claim>> BuildUserClaimsAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            return claims;
        }

        private JwtSecurityToken GenerateJwt(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(double.Parse(_config["JwtSettings:ExpiresInMinutes"]));

            return new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );
        }



        #endregion
    }
}
