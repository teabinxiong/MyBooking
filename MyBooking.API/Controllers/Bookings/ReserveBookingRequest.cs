namespace MyBooking.API.Controllers.Bookings
{
    public sealed record ReserveBookingRequest(
        Guid ApartmentId,
        Guid UserId,
        String StartDate,
        String EndDate
    );
}
