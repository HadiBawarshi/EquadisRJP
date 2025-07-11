using EquadisRJP.Application.Common;
using System.Security.Claims;

namespace EquadisRJP.Service.Security
{
    public sealed class CurrentParty : ICurrentParty
    {
        public int? SupplierId { get; }
        public int? RetailerId { get; }

        public CurrentParty(IHttpContextAccessor accessor)
        {
            var user = accessor.HttpContext?.User;

            if (user is null) return;

            if (user.FindFirstValue("supplier_id") is string s && int.TryParse(s, out var sid))
                SupplierId = sid;

            if (user.FindFirstValue("retailer_id") is string r && int.TryParse(r, out var rid))
                RetailerId = rid;
        }
    }
}
