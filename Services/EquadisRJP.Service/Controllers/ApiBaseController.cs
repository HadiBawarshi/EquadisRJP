using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquadisRJP.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public ApiBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
