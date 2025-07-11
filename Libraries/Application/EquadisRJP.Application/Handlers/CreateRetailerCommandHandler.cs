using EquadisRJP.Application.Commands;
using EquadisRJP.Application.ExternalServices;
using EquadisRJP.Domain.Entities;
using EquadisRJP.Domain.Errors;
using EquadisRJP.Domain.Primitives;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.IdentityAuth.Public.Constants;
using EquadisRJP.IdentityAuth.Public.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EquadisRJP.Application.Handlers
{
    public class CreateRetailerCommandHandler : IRequestHandler<CreateRetailerCommand, Result>
    {

        private readonly IIdentityAuthClient _auth;
        private readonly IRetailerRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CreateRetailerCommandHandler> _log;

        public CreateRetailerCommandHandler(IIdentityAuthClient auth, IRetailerRepository repo, IUnitOfWork uow, ILogger<CreateRetailerCommandHandler> logger)
        {
            _auth = auth;
            _repo = repo;
            _uow = uow;
            _log = logger;

        }

        public async Task<Result> Handle(CreateRetailerCommand rq, CancellationToken ct)
        {
            // 1. Register Identity user
            var reg = await _auth.RegisterAsync(
                new RegisterUserDto(rq.StoreName, rq.Username, rq.Email, rq.Password, rq.PhoneNumber, IdentityRoles.Retailer), ct);

            if (!reg.Success || string.IsNullOrWhiteSpace(reg.UserId))
                return Result.Failure(DomainErrors.Retailer.CreationFailed);

            // 2. Create Retailer 
            Retailer retailer = Retailer.Create(rq.StoreName, rq.StoreTypeId, rq.Location, reg.UserId);

            _log.LogInformation("Retailer {RetailerId} created for User {UserId}", retailer.Id, reg.UserId);


            await _repo.AddAsync(retailer, ct);
            await _uow.SaveChangesAsync(ct);

            return Result.Success();

        }
    }
}
