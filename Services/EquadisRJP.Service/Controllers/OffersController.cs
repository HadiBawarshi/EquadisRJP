using EquadisRJP.Application.Commands;
using EquadisRJP.Application.Common;
using EquadisRJP.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquadisRJP.Service.Controllers
{

    public class OffersController : ApiBaseController
    {
        private readonly ICurrentParty _currentParty;

        public OffersController(IMediator mediator, ICurrentParty currentParty) : base(mediator)
        {
            _currentParty = currentParty;

        }

        [Authorize(Roles = "Supplier")]
        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] CreateOfferDto dto)
        {
            var result = await _mediator.Send(new CreateOfferCommand(dto.Title, dto.ValidFrom, dto.ValidTo, dto.DiscountValuePercentage, _currentParty.SupplierId.Value));
            return Ok(result);
        }


        [Authorize(Roles = "Supplier")]
        [HttpPut()]
        public async Task<IActionResult> UpdateOffer([FromBody] UpdateOfferDto dto)
        {

            var result = await _mediator.Send(new UpdateOfferCommand(dto.OfferId, dto.Title, dto.ValidFrom, dto.ValidTo, dto.DiscountValuePercentage, dto.Archive, _currentParty.SupplierId.Value));
            return Ok(result);               // Result
        }
    }
}
