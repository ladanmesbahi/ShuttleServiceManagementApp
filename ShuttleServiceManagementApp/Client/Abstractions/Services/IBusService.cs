using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Shared.Requests;
using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Client.Abstractions.Services
{
	public interface IBusService
	{
		List<BusResponse> Buses { get; set; }
		event Action BusListChanged;
		Task<Result> CreateBus(RegisterBusRequest bus);
		Task<Result> Delete(Guid id);
		Task GetBuses();
	}
}
