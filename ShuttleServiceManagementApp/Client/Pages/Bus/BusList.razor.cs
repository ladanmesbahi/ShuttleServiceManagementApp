using MudBlazor;
using ShuttleServiceManagementApp.Client.Messages;
using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Client.Pages.Bus
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
                if (response.IsFailure)
                {
                    await DialogService.ShowMessageBox(
                            UserMessages.Error,
                            response.Error.Message,
                            options: new DialogOptions
                            { MaxWidth = MaxWidth.Medium, FullWidth = false });
                }
                else
                {
                    Snackbar.Configuration.VisibleStateDuration = 3000;
                    Snackbar.Add(UserMessages.DeletionSuccess, Severity.Success);
                    await BusService.GetBuses();
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
