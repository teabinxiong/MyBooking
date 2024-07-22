using MyBooking.Application.Abstractions.Authentication;
using MyBooking.Application.Abstractions.Messaging;
using MyBooking.Domain.Abstractions;
using MyBooking.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Application.Users.RegisterUser
{
    internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(
            IAuthenticationService authenticationService,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork
            )
        {
            _authenticationService = authenticationService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<Guid>> Handle(
            RegisterUserCommand request, 
            CancellationToken cancellationToken)
        {
            var user = User.Create(
                new FirstName(request.FirstName),
                new LastName(request.LastName),
                new Email(request.Email)
                );

            var identityId = await _authenticationService.RegisterAsync(
                user,
                request.Password,
                cancellationToken
                );

            user.SetIdentityId(identityId);

            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync();

            return user.Id;
        }
    }
}
