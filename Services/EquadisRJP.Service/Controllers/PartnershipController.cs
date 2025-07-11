using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Common;
using EquadisRJP.Application.Dtos;
using EquadisRJP.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EquadisRJP.Service.Controllers
{

    public class PartnershipController : ApiBaseController
    {

        private readonly ICurrentParty _currentParty;

        public PartnershipController(IMediator mediator, ICurrentParty currentParty) : base(mediator)
        {
            _currentParty = currentParty;

        }


        [Authorize(Roles = "Supplier")]
        [HttpPost(Name = "CreatePartnership")]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public async Task<IActionResult> CreatePartnership([FromForm] StartPartnershipDto dto)
        {
            var result = await _mediator.Send(new StartPartnershipCommand(_currentParty.SupplierId.Value, dto.RetailerId, dto.ExpiryDate));
            return Ok(result);
        }




        [Authorize(Roles = "Supplier")]
        [HttpPatch(Name = "Expire")]
        public async Task<IActionResult> Expire([FromBody] ExpirePartnershipDto dto)
        {
            var result = await _mediator.Send(new ExpirePartnershipCommand(_currentParty.SupplierId.Value, dto.PartnershipId));
            return Ok(result);
        }

        [Authorize(Roles = "Supplier")]
        [HttpPatch(Name = "Renew")]
        public async Task<IActionResult> Renew([FromBody] RenewPartnershipDto dto)
        {
            var result = await _mediator.Send(new RenewPartnershipCommand(_currentParty.SupplierId.Value, dto.PartnershipId, dto.NewExpiryDate));
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet(Name = "GetActivePartnerships")]
        public async Task<IActionResult> GetActivePartnerships()
        {
            var result = await _mediator.Send(new GetActivePartnershipsQuery());
            return Ok(result);
        }
    }
}
