﻿using MyBooking.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Domain.Bookings
{
    public record PricingDetails(
        Money PriceForPeriod, 
        Money CleaningFee,
        Money AmenitiesUpCharge,
        Money TotalPrice
        );
}
