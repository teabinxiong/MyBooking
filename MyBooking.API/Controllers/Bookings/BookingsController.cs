﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooking.API.Controllers.Bookings;
using MyBooking.Application.Bookings.GetBooking;
using MyBooking.Application.Bookings.ReserveBooking;
using System.Globalization;

namespace MyBooking.API.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ISender _sender;
        public BookingsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(
            Guid id,
            CancellationToken ct
        )
        {
            var query = new GetBookingQuery(id);

            var result = await _sender.Send(query, ct);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost()]
        public async Task<IActionResult> ReserveBooking(
            ReserveBookingRequest request,
            CancellationToken ct
        )
        {
            var startDateObj = DateOnly.ParseExact(request.StartDate, "M-d-yyyy", CultureInfo.InvariantCulture);
            var endDateObj = DateOnly.ParseExact(request.EndDate, "M-d-yyyy", CultureInfo.InvariantCulture);


            var command = new ReserveBookingCommand(
                request.ApartmentId,
                request.UserId,
                startDateObj,
                endDateObj
                );

            var result = await _sender.Send(command ,ct);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
        }
    }
}
