using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public class StartPartnershipCommand : IRequest<Result>
    {
        public int SupplierId { get; set; }
        public int RetailerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
