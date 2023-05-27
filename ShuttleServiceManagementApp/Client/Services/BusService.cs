using ShuttleServiceManagementApp.Client.Abstractions.Services;
using ShuttleServiceManagementApp.Shared.Responses;
using ShuttleServiceManagementApp.Shared.Requests;
using System.Net.Http.Json;

namespace ShuttleServiceManagementApp.Client.Services
{
	public class BusService : IBusService
	{
		private readonly HttpClient _httpClient;

		public BusService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public List<BusResponse> Buses { get; set; }

		public event Action BusListChanged;

		public async Task<Guid> CreateBus(RegisterBusRequest bus)
		{
			var response = await _httpClient.PostAsJsonAsync<RegisterBusRequest>("api/bus", bus);
			return await response.Content.ReadFromJsonAsync<Guid>();
		}

		public async Task<HttpResponseMessage> Delete(Guid id)
		{
			var response = await _httpClient.DeleteAsync($"/api/bus/{id}");
			return response;
		}

		public async Task GetBuses()
		{
			Buses = await _httpClient.GetFromJsonAsync<List<BusResponse>>("/api/bus");
			BusListChanged.Invoke();
		}
	}
}
