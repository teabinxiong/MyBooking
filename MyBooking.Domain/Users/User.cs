using MyBooking.Domain.Abstractions;
using MyBooking.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Domain.Users
{
    public sealed class User : Entity
    {
        private User()
        {

        }

        private User(Guid id, FirstName firstName, LastName lastName, Email email) : base(id)
        {
        }

        public FirstName FirstName { get; private set; }

        public LastName LastName { get; private set; }

        public Email Email { get; private set; }

        public string IdentityId { get; private set; } = string.Empty;

        public static User Create(FirstName firstName, LastName lastName, Email email)
        {
            var user = new User(Guid.NewGuid(), firstName, lastName, email);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }

        public void SetIdentityId(string identityId)
        {
            IdentityId = identityId;
        }

    }
}
