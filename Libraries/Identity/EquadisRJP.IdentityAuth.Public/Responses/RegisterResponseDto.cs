namespace EquadisRJP.IdentityAuth.Public.Responses
{
    public class RegisterResponseDto
    {
        public RegisterResponseDto()
        {
        }

        public RegisterResponseDto(bool success, string? userId)
        {
            Success = success;
            UserId = userId;
        }

        public bool Success { get; set; }
        public string? UserId { get; set; }
    }
}
