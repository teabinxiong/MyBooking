using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyBooking.Domain.Apartments;
using MyBooking.Domain.Bookings;
using MyBooking.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Infrastructure.Repositories
{
    internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private static readonly BookingStatus[] ActiveBookingStatuses =
        {
            BookingStatus.Reserved,
            BookingStatus.Confirmed,
            BookingStatus.Completed
        };

        public BookingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsOverlappingAsync(
            Apartment apartment,
            DateRange duration,
            CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<Booking>()
                .AnyAsync(
                    booking =>
                        booking.ApartmentId == apartment.Id &&
                        booking.Duration.Start == duration.End &&
                        booking.Duration.End == duration.Start &&
                        ActiveBookingStatuses.Contains(booking.Status),
                    cancellationToken
                );
        }
    }
}
