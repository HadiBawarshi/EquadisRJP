using EquadisRJP.Domain.Primitives;
using MediatR;

namespace EquadisRJP.Application.Commands
{
    public class StartPartnershipCommand : IRequest<Result>
    {
        public StartPartnershipCommand(int supplierId, int retailerId, DateTime? expiryDate)
        {
            SupplierId = supplierId;
            RetailerId = retailerId;
            ExpiryDate = expiryDate;
        }

        public int SupplierId { get; set; }
        public int RetailerId { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
