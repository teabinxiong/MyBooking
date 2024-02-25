using MyBooking.Application.Abstractions.Clock;
using MyBooking.Application.Abstractions.Messaging;
using MyBooking.Application.Exceptions;
using MyBooking.Domain.Abstractions;
using MyBooking.Domain.Apartments;
using MyBooking.Domain.Bookings;
using MyBooking.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Application.Bookings.ReserveBooking
{
    internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PricingService _pricingService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReserveBookingCommandHandler(
            IUserRepository userRepository, 
            IApartmentRepository apartmentRepository,
            IBookingRepository bookingRepository, 
            IUnitOfWork unitOfWork, 
            PricingService pricingService,
            IDateTimeProvider dateTimeProvider
            )
        {
            _userRepository = userRepository;
            _apartmentRepository = apartmentRepository;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _pricingService = pricingService;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if(user is null) {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }

            var apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId, cancellationToken);

            if(apartment is null)
            {
                return Result.Failure<Guid>(ApartmentErrors.NotFound);
            }

            var duration = DateRange.Create(request.StartDate, request.EndDate);

            if(await _bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken))
            {
                return Result.Failure<Guid>(BookingErrors.Overlap);
            }

            try
            {
                var booking = Booking.Reserve(
                    apartment,
                    user.Id,
                    duration,
                    utcNow: _dateTimeProvider.UtcNow,
                    _pricingService
                    );

                _bookingRepository.Add(booking);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return booking.Id;
            }
            catch(ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingErrors.Overlap);
            }
        }
    }
}
