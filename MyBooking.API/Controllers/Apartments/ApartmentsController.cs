using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Apartments.SearchApartments;

namespace MyBooking.API.Controllers.Apartments
{
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly ISender _sender;
        public ApartmentsController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet]
        public async Task<IActionResult> SearchApartments(
            DateOnly startDate,
            DateOnly endDate,
            CancellationToken ct
        )
        {
            var query = new SearchApartmentsQuery(startDate, endDate);

            var result = await _sender.Send(query, ct);

            return Ok(result.Value);
        }
    }
}
