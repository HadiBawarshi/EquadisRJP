using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public class CreateRetailerCommand : IRequest<Result>
    {

        public string? StoreName { get; set; }

        public int? StoreTypeId { get; set; }

        public string? Location { get; set; }
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
