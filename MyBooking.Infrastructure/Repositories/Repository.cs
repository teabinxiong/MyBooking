using Microsoft.EntityFrameworkCore;
using MyBooking.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Infrastructure.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {

        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {

            DbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<T>()
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            DbContext.Add(entity);
        }
    }
}
