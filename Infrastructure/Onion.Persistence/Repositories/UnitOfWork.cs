using Onion.Application.Interfaces;
using Onion.Persistence.Context;

namespace Onion.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await appDbContext.SaveChangesAsync() > 0;
        }
    }
}
