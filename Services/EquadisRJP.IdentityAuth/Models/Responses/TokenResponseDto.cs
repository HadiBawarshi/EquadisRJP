namespace EquadisRJP.IdentityAuth.Models.Responses
{
    public class TokenResponseDto
    {
        public string? AccessToken { get; set; }
        public string TokenType { get; set; } = "Bearer";
        public int ExpiresIn { get; set; }
    }
}
