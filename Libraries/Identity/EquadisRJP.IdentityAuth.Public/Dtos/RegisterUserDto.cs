namespace EquadisRJP.IdentityAuth.Public.Dtos
{
    public class RegisterUserDto
    {
        public RegisterUserDto()
        {
        }

        public RegisterUserDto(string? name, string? username, string? email, string password, string? phoneNumber, string? role)
        {
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
    }
}
