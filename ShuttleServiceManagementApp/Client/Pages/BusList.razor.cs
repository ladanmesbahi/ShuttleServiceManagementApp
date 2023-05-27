using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Client.Pages
{
	public partial class BusList : IDisposable
	{
		private BusResponse bus = new BusResponse();
		protected void Delete_Click(Guid id)
		{
			bus = BusService.Buses.FirstOrDefault(b => b.Id == id);
			DeleteConfirmation.Show();
		}
		protected Components.ConfirmBase DeleteConfirmation { get; set; }
		protected async Task ConfirmDelete_Click(bool deleteConfirmed)
		{
			if (deleteConfirmed)
			{
				var response = await BusService.Delete(bus.Id);
				switch (response.StatusCode)
				{
					case System.Net.HttpStatusCode.OK:
						Snackbar.Configuration.VisibleStateDuration = 3000;
						Snackbar.Add("حذف با موفقیت انجام شد.", MudBlazor.Severity.Success);
						await BusService.GetBuses();
						break;
					default:
						await DialogService.ShowMessageBox(
						"خطا",
						await response.Content.ReadAsStringAsync(),
						options: new MudBlazor.DialogOptions { MaxWidth = MudBlazor.MaxWidth.Medium, FullWidth = false });
						break;
				}
			}
		}
		public void Dispose()
		{
			BusService.BusListChanged -= StateHasChanged;
		}

		protected override async Task OnInitializedAsync()
		{
			BusService.BusListChanged += StateHasChanged;
			await BusService.GetBuses();
		}
	}
}
