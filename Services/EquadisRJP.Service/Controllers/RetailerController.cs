using EquadisRJP.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EquadisRJP.Service.Controllers
{

    public class RetailerController : ApiBaseController
    {
        public RetailerController(IMediator mediator) : base(mediator)
        {
        }



        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "CreateRetailer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateRetailer([FromForm] CreateRetailerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
