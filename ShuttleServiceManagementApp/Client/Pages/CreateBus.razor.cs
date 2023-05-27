using ShuttleServiceManagementApp.Shared.Requests;

namespace ShuttleServiceManagementApp.Client.Pages
{
	public partial class CreateBus
	{
		RegisterBusRequest bus = new RegisterBusRequest();

		async Task AddBus()
		{
			await BusService.CreateBus(bus);
			NavigationManager.NavigateTo("/busList");
		}
	}
}
