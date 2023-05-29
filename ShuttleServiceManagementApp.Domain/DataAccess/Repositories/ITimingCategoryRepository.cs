using ShuttleServiceManagementApp.Domain.Entities;

namespace ShuttleServiceManagementApp.Domain.DataAccess.Repositories
{
    public interface ITimingCategoryRepository
    {
        Task Add(TimingCategory timingCategory);
        Task Delete(TimingCategory timingCategory);
        Task<IEnumerable<TimingCategory>> GetAll(CancellationToken cancellationToken);
        Task<TimingCategory> GetById(Guid id, CancellationToken cancellationToken);
    }
}
