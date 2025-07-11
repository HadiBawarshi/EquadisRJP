using EquadisRJP.Application.Commands;
using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Errors;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using MediatR;

namespace EquadisRJP.Application.Handlers
{
    public class StartPartnershipCommandHandler : IRequestHandler<StartPartnershipCommand, Result>
    {

        private readonly IPartnershipRepository _repository;
        private readonly IUnitOfWork _uow;

        public StartPartnershipCommandHandler(IPartnershipRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<Result> Handle(StartPartnershipCommand rq, CancellationToken ct)
        {
            // Optional: prevent duplicate active partnerships
            if (await _repository.ExistsActiveAsync(rq.SupplierId, rq.RetailerId))
                return Result.Failure(DomainErrors.Partnership.AlreadyExists);

            var partnership = Partnership.Start(rq.SupplierId, rq.RetailerId, rq.StartDate, rq.ExpiryDate);

            await _repository.AddAsync(partnership, ct);
            await _uow.SaveChangesAsync(ct);

            return Result.Success();
        }
    }
}

