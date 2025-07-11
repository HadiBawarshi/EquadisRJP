using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public class CreateSupplierCommand() : IRequest<Result>
    {
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? CountryId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }


    }
}
