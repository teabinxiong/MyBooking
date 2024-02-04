using MyBooking.Domain.Abstractions;

namespace MyBooking.Domain.Users.Events
{
    public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
}
