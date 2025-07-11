using EquadisRJP.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace EquadisRJP.Service.Security
{
    public class PartyClaimsTransformer : IClaimsTransformation
    {

        private readonly ISupplierRepository _supRepo;
        private readonly IRetailerRepository _retRepo;
        private readonly IMemoryCache _cache;

        public PartyClaimsTransformer(ISupplierRepository supRepo, IRetailerRepository retRepo, IMemoryCache cache)
        {
            _supRepo = supRepo;
            _retRepo = retRepo;
            _cache = cache;
        }


        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // token already validated – just enrich
            var uid = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = principal.FindFirstValue(ClaimTypes.Role);

            if (uid is null || role is null) return principal;

            var cacheKey = $"party:{role}:{uid}";
            var partyGuid = await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(4);
                entry.SlidingExpiration = TimeSpan.FromMinutes(20);

                return role switch
                {
                    "Supplier" => await _supRepo.GetSupplierIdByUserIdAsync(uid),
                    "Retailer" => await _retRepo.GetRetailerIdByUserIdAsync(uid),
                    _ => null
                };
            });

            if (partyGuid is null) return principal;

            var clone = new ClaimsIdentity(principal.Identity);
            clone.AddClaim(new Claim($"{role.ToLower()}_id", partyGuid.ToString()));
            return new ClaimsPrincipal(clone);
        }

    }
}
