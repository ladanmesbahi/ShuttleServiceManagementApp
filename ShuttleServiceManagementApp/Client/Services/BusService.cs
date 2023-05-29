using ShuttleServiceManagementApp.Client.Abstractions.Services;
using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Shared.Requests;
using ShuttleServiceManagementApp.Shared.Responses;
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

		public async Task<Result> CreateBus(RegisterBusRequest bus)
		{
			var response = await _httpClient.PostAsJsonAsync<RegisterBusRequest>("api/bus", bus);
			return await GenerateResult(response);
		}

		private static async Task<Result> GenerateResult(HttpResponseMessage response)
		{
			return response.IsSuccessStatusCode ?
							Result.Success() :
							Result.Failure(await response.Content.ReadFromJsonAsync<Error>());
		}

		public async Task<Result> Delete(Guid id)
		{
			var response = await _httpClient.DeleteAsync($"/api/bus/{id}");
			return await GenerateResult(response);
		}

		public async Task GetBuses()
		{
			Buses = await _httpClient.GetFromJsonAsync<List<BusResponse>>("/api/bus");
			BusListChanged.Invoke();
		}
	}
}
