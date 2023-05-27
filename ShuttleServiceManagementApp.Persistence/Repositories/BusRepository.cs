using Microsoft.EntityFrameworkCore;
using ShuttleServiceManagementApp.Domain.DataAccess.Repositories;
using ShuttleServiceManagementApp.Domain.Entities;

namespace ShuttleServiceManagementApp.Persistence.Repositories
{
	public class BusRepository : IBusRepository
	{
		private readonly DbSet<Bus> _busses;

		public BusRepository(AppDbContext context)
		{
			_busses = context.Set<Bus>();
		}
		public async Task Add(Bus bus)
		{
			_busses.Add(bus);
		}

		public async Task Delete(Bus bus)
		{
			_busses.Remove(bus);
		}

		public async Task<IEnumerable<Bus>> GetAll(CancellationToken cancellationToken)
		{
			return _busses.AsEnumerable();
		}

		public async Task<Bus> GetById(Guid id, CancellationToken cancellationToken = default)
		{
			return await _busses.FirstOrDefaultAsync(bus => bus.Id == id, cancellationToken);
		}
	}
}
