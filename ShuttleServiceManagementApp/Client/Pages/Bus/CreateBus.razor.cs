using MudBlazor;
using ShuttleServiceManagementApp.Client.Messages;
using ShuttleServiceManagementApp.Shared.Requests;

namespace ShuttleServiceManagementApp.Client.Pages.Bus
{
	public partial class CreateBus
	{
		RegisterBusRequest bus = new RegisterBusRequest();

		async Task AddBus()
		{
			var response = await BusService.CreateBus(bus);
			if (response.IsSuccess)
				NavigationManager.NavigateTo("/busList");
			else
			{
				await DialogService.ShowMessageBox(
						UserMessages.Error,
						response.Error.Message,
						options: new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = false });
			}
		}
	}
}
