using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Common;
using EquadisRJP.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquadisRJP.Service.Controllers
{

    public class OfferSubscriptions : ApiBaseController
    {

        private readonly ICurrentParty _currentParty;

        public OfferSubscriptions(IMediator mediator, ICurrentParty currentParty) : base(mediator)
        {
            _currentParty = currentParty;

        }

        [Authorize(Roles = "Retailer")]
        [HttpPost(Name = "subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] int OfferId)
        {
            var result = await _mediator.Send(new SubscribeToOfferCommand(_currentParty.RetailerId.Value, OfferId));
            return Ok(result);
        }

        [Authorize(Roles = "Retailer")]
        [HttpDelete(Name = "unsubscribe")]
        public async Task<IActionResult> Unsubscribe([FromBody] int OfferId)
        {
            var result = await _mediator.Send(new UnsubscribeFromOfferCommand(_currentParty.RetailerId.Value, OfferId));
            return Ok(result);
        }


        [Authorize(Roles = "Retailer")]
        [HttpGet(Name = "GetCurrentOffers")]
        public async Task<IActionResult> GetCurrentOffers()
        {

            var result = await _mediator.Send(new GetCurrentOffersForRetailerQuery(_currentParty.RetailerId.Value));
            return Ok(result);
        }
    }
}
