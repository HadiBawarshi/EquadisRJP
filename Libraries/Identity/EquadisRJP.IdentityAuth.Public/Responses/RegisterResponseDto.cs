namespace EquadisRJP.IdentityAuth.Public.Responses
{
    public class RegisterResponseDto
    {
        public RegisterResponseDto()
        {
        }

        public RegisterResponseDto(bool success, string? userId, string? message = "")
        {
            Success = success;
            UserId = userId;
            Message = message;
        }

        public bool Success { get; set; }
        public string? UserId { get; set; }
        public string? Message { get; set; }
    }
}
