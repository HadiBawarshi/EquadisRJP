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
    public sealed class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Result>
    {

        private readonly IIdentityAuthClient _auth;
        private readonly ISupplierRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CreateSupplierCommandHandler> _log;

        public CreateSupplierCommandHandler(IIdentityAuthClient auth, ISupplierRepository repo, IUnitOfWork uow, ILogger<CreateSupplierCommandHandler> logger)
        {
            _auth = auth;
            _repo = repo;
            _uow = uow;
            _log = logger;
        }

        public async Task<Result> Handle(CreateSupplierCommand rq, CancellationToken ct)
        {
            // 1. Register Identity user
            var reg = await _auth.RegisterAsync(
                new RegisterUserDto(rq.CompanyName, rq.Username, rq.Email, rq.Password, rq.PhoneNumber, IdentityRoles.Supplier), ct);

            if (!reg.Success || string.IsNullOrWhiteSpace(reg.UserId))
                return Result.Failure(DomainErrors.Supplier.CreationFailed);

            // 2. Create supplier 
            Supplier supplier = Supplier.Create(rq.CompanyName, rq.CountryId, reg.UserId);

            _log.LogInformation("Supplier {SupplierId} created for User {UserId}", supplier.Id, reg.UserId);


            await _repo.AddAsync(supplier, ct);
            await _uow.SaveChangesAsync(ct);


            return Result.Success();
        }
    }
}
