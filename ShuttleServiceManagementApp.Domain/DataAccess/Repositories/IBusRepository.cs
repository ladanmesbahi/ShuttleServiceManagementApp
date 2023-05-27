using ShuttleServiceManagementApp.Domain.Entities;

namespace ShuttleServiceManagementApp.Domain.DataAccess.Repositories
{
    public interface IBusRepository
    {
        Task Add(Bus bus);
		Task Delete(Bus bus);
		Task<IEnumerable<Bus>> GetAll(CancellationToken cancellationToken);
        Task<Bus> GetById(Guid id, CancellationToken cancellationToken = default);
    }
}
