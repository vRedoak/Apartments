using Apartments.Features.Query;
using Apartments.Models.Apartment;
using Apartments.Models.Apartment.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Apartments.Controllers
{
    [Produces("application/json")]
    [Route("api/apartments")]
    public class ApartmentsController : Controller
    {
        private readonly ILogger<ApartmentsController> _logger;
        private readonly IMediator _mediator;

        public ApartmentsController(ILogger<ApartmentsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all apartments
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <param name="top"></param>
        /// <param name="skip"></param>
        /// <returns>User profiles</returns>
        /// <response code="200">Returns user profiles</response>
        [HttpPost]
        [Route("search")]
        [ProducesResponseType(typeof(GetApartmentsViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetApartmentsViewModel>> ApartmentsSearch([FromBody] GetAppartmentsRequest searchRequest, int top = 30, int skip = 0)
        {
            return await _mediator.Send(new GetAppartmentsQuery(searchRequest, top, skip)); //random comment123
        }
    }
}
