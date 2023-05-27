using ShuttleServiceManagementApp.Shared.Responses;
using ShuttleServiceManagementApp.Shared.Requests;

namespace ShuttleServiceManagementApp.Client.Abstractions.Services
{
	public interface IBusService
	{
		List<BusResponse> Buses { get; set; }
		event Action BusListChanged;
		Task<Guid> CreateBus(RegisterBusRequest bus);
		Task<HttpResponseMessage> Delete(Guid id);
		Task GetBuses();
	}
}
