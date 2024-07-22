using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Apartments.SearchApartments;
using System.Globalization;

namespace MyBooking.API.Controllers.Apartments
{
    [Authorize]
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
            string startDate,
            string endDate,
            CancellationToken ct
        )
        {
            var startDateObj = DateOnly.ParseExact(startDate,"M-d-yyyy", CultureInfo.InvariantCulture);
            var endDateObj = DateOnly.ParseExact(endDate, "M-d-yyyy", CultureInfo.InvariantCulture); 

            var query = new SearchApartmentsQuery(startDateObj, endDateObj);

            var result = await _sender.Send(query, ct);

            return Ok(result.Value);
        }
    }
}
