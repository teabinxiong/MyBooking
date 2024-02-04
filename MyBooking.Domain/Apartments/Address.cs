using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Domain.Apartments
{
    public record Address(
         string Country,
         string State ,
         string ZipCode,
         string City ,
         string Street 
        );
}
