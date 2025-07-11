using EquadisRJP.Application.Commands;
using EquadisRJP.Domain.Errors;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;
using static EquadisRJP.Domain.Entities.Partnership;

namespace EquadisRJP.Application.Handlers
{
    public class ExpirePartnershipHandler : IRequestHandler<ExpirePartnershipCommand, Result>
    {
        private readonly IPartnershipRepository _repo;
        private readonly IUnitOfWork _uow;

        public ExpirePartnershipHandler(IPartnershipRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Result> Handle(ExpirePartnershipCommand rq, CancellationToken ct)
        {
            var partnership = await _repo.GetByIdAsync(rq.PartnershipId, ct);
            if (partnership is null)
                return Result.Failure(DomainErrors.Partnership.NotFound);

            if (partnership.StatusId == (int)PartnershipStatus.Expired)
                return Result.Failure(DomainErrors.Partnership.AlreadyExpired);

            partnership.Expire();
            await _uow.SaveChangesAsync(ct);

            return Result.Success();
        }
    }

}
