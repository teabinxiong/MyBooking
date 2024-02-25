﻿using MyBooking.Domain.Abstractions;
using MyBooking.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Domain.Apartments
{
    public sealed class Apartment : Entity
    {
        private Apartment()
        {

        }

        public Apartment(
            Guid id,
            Name name,
            Description description,
            Address address,
            Money price,
            Money cleaningFee,
            List<Amenity> amenities
            ) : base(id)
        {
        }

        public Name Name { get; private set; }

        public Description Description { get; private set; }

        public Address Address { get; private set; }

        public Money Price { get; private set; }
    
        public Money CleaningFee { get; private set; }

        public DateTime? LastBookedOnUtc { get; internal set; }

        public List<Amenity> Amenities { get; private set; } = new();
    }
}