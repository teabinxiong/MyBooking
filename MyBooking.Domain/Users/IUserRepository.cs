using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid, CancellationToken cancellationToken = default);

        void Add(User user);
    }
}
