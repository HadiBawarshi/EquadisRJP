namespace EquadisRJP.IdentityAuth.Models.Dtos
{
    public class TokenRequestDto
    {
        public string? GrantType { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Scope { get; set; }
    }
}
