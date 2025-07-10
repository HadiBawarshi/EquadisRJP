using EquadisRJP.Application.Commands;
using EquadisRJP.Domain.Errors;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;

namespace EquadisRJP.Application.Handlers
{
    public class RenewPartnershipCommandHandler : IRequestHandler<RenewPartnershipCommand, Result>
    {
        private readonly IPartnershipRepository _repo;
        private readonly IUnitOfWork _uow;

        public RenewPartnershipCommandHandler(IPartnershipRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Result> Handle(RenewPartnershipCommand rq, CancellationToken ct)
        {
            var partnership = await _repo.GetByIdAsync(rq.PartnershipId, ct);
            if (partnership is null)
                return Result.Failure(DomainErrors.Partnership.NotFound);

            try
            {
                partnership.Renew(rq.NewExpiryDate);
            }
            catch (InvalidOperationException)
            {
                return Result.Failure(DomainErrors.Partnership.NotExpired);
            }

            await _uow.SaveChangesAsync(ct);
            return Result.Success();
        }
    }

}
