using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Domain.Bookings
{
    public enum BookingStatus
    {
        Reserved = 1,
        Confirmed = 2,
        Rejected = 3,
        Cancelled = 4,
        Completed = 5
    }
}
