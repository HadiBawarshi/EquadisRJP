using EquadisRJP.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EquadisRJP.Service.Controllers
{

    public class SupplierController : ApiBaseController
    {
        public SupplierController(IMediator mediator) : base(mediator)
        {
        }
        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "CreateSupplier")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateSupplier([FromForm] CreateSupplierCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
