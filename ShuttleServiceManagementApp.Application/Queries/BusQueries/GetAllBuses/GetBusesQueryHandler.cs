using ShuttleServiceManagementApp.Application.Abstractions.Messaging;
using ShuttleServiceManagementApp.Domain.DataAccess.Repositories;
using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Application.Queries.BusQueries.GetAllBuses
{
	internal class GetBusesQueryHandler : IQueryHandler<GetBusesQuery, List<BusResponse>>
	{
		private readonly IBusRepository _busRepository;

		public GetBusesQueryHandler(IBusRepository busRepository)
		{
			_busRepository = busRepository;
		}
		public async Task<Result<List<BusResponse>>> Handle(GetBusesQuery request, CancellationToken cancellationToken)
		{
			var buses = await _busRepository.GetAll(cancellationToken);
			var result = new List<BusResponse>();
			foreach (var bus in buses)
				result.Add(new BusResponse(bus.Id, bus.DriverName.Value, bus.Capacity));

			return result;
		}
	}
}
