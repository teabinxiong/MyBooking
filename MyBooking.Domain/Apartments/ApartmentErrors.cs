using MyBooking.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Domain.Apartments
{
    public static class ApartmentErrors
    {
        public static Error NotFound = new(
            "Apartment.NotFound",
            "The apartment with the specified identifier was not found");
    }
}
