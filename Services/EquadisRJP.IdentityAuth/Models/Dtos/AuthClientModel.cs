namespace EquadisRJP.IdentityAuth.Models.Dtos
{
    public class AuthClientModel
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string[]? AllowedGrantTypes { get; set; }
        public string[]? AllowedScopes { get; set; }
    }
}
