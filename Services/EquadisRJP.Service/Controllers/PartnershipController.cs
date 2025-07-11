using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EquadisRJP.Service.Controllers
{

    public class PartnershipController : ApiBaseController
    {
        public PartnershipController(IMediator mediator) : base(mediator)
        {
        }


        [Authorize(Roles = "Supplier")]
        [HttpPost(Name = "CreatePartnership")]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public async Task<IActionResult> CreatePartnership([FromForm] StartPartnershipCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }




        [Authorize(Roles = "Admin,Supplier")]
        [HttpPatch(Name = "Expire")]
        public async Task<IActionResult> Expire([FromForm] ExpirePartnershipCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Supplier")]
        [HttpPatch(Name = "Renew")]
        public async Task<IActionResult> Renew([FromForm] RenewPartnershipCommand command)
        {
            var result = await _mediator.Send(command);
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
