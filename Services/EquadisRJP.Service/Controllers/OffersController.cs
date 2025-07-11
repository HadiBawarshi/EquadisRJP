using EquadisRJP.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquadisRJP.Service.Controllers
{

    public class OffersController : ApiBaseController
    {
        public OffersController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(Roles = "Supplier")]
        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] CreateOfferCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [Authorize(Roles = "Supplier")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOffer([FromBody] UpdateOfferCommand command)
        {

            var result = await _mediator.Send(command);
            return Ok(result);               // Result
        }
    }
}
