﻿using MyBooking.Domain.Abstractions;

namespace MyBooking.Domain.Reviews.Events
{
    public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
}