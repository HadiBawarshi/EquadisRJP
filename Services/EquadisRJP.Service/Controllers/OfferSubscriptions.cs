using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquadisRJP.Service.Controllers
{

    public class OfferSubscriptions : ApiBaseController
    {
        public OfferSubscriptions(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(Roles = "Retailer")]
        [HttpPost(Name = "subscribe")]
        public async Task<IActionResult> Subscribe(SubscribeToOfferCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Retailer")]
        [HttpDelete(Name = "unsubscribe")]
        public async Task<IActionResult> Unsubscribe(UnsubscribeFromOfferCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [Authorize(Roles = "Retailer")]
        [HttpGet(Name = "GetCurrentOffers")]
        public async Task<IActionResult> GetCurrentOffers()
        {
            int retailerId = 1;  // claim helper
            var result = await _mediator.Send(new GetCurrentOffersForRetailerQuery(retailerId));
            return Ok(result);
        }
    }
}
