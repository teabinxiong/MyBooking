using MyBooking.Domain.Abstractions;

namespace MyBooking.Domain.Users.Events
{
    public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
}
