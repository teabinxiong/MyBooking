using MyBooking.Domain.Abstractions;

namespace MyBooking.Domain.Users.Events
{
    public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
}
