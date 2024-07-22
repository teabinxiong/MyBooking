using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Application.Users.RegisterUser
{
    internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator() 
        {
            RuleFor(c => c.FirstName).NotEmpty();

            RuleFor(c => c.LastName).NotEmpty();

            RuleFor(c => c.Email).EmailAddress();

            RuleFor(c => c.Password).NotEmpty().MinimumLength(5);

        }
    }
}
