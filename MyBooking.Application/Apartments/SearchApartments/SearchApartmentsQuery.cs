using MyBooking.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Application.Apartments.SearchApartments
{
    public sealed record SearchApartmentsQuery(
     DateOnly StartDate,
     DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;
}
