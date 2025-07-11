using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Queries;
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

        [Authorize(Roles = "Admin")]
        [HttpGet("{retailerId}")]
        public async Task<IActionResult> GetSuppliersOfRetailer(int retailerId)
        {
            var result = await _mediator.Send(new GetSuppliersOfRetailerQuery(retailerId));
            return Ok(result);
        }


    }
}
