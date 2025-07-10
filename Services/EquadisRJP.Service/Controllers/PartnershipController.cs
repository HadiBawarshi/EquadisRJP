using EquadisRJP.Application.Commands;
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
    }
}
