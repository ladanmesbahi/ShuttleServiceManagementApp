using Microsoft.EntityFrameworkCore;
using ShuttleServiceManagementApp.Domain.DataAccess.Repositories;
using ShuttleServiceManagementApp.Domain.Entities;

namespace ShuttleServiceManagementApp.Persistence.Repositories
{
    public class TimingCategoryRepository : ITimingCategoryRepository
    {
        private readonly DbSet<TimingCategory> _timingCategories;
        public TimingCategoryRepository(AppDbContext context)
        {
            _timingCategories = context.Set<TimingCategory>();
        }

        public async Task Add(TimingCategory timingCategory)
        {
            _timingCategories.Add(timingCategory);
        }

        public async Task Delete(TimingCategory timingCategory)
        {
            _timingCategories.Remove(timingCategory);
        }

        public async Task<IEnumerable<TimingCategory>> GetAll(CancellationToken cancellationToken)
        {
            return _timingCategories.AsEnumerable();
        }

        public async Task<TimingCategory> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _timingCategories.FirstOrDefaultAsync(tc => tc.Id == id, cancellationToken);
        }
    }
}
