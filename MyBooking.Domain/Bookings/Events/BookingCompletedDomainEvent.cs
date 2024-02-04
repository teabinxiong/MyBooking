using MyBooking.Domain.Abstractions;

namespace MyBooking.Domain.Users.Events
{
    public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
}
