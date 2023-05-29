using MudBlazor;
using ShuttleServiceManagementApp.Client.Messages;
using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Client.Pages.TimingCategory
{
    public partial class TimingCategoryList : IDisposable
    {
        private TimingCategoryResponse timingCategory = new TimingCategoryResponse();
        protected Components.ConfirmBase DeleteConfirmation { get; set; }
        protected override async Task OnInitializedAsync()
        {
            TimingCategoryService.TimingCategoriesChanged += StateHasChanged;
            await TimingCategoryService.GetTimingCategories();
        }
        public void Dispose()
        {
            TimingCategoryService.TimingCategoriesChanged -= StateHasChanged;
        }
        private void Delete_Clicked(Guid id)
        {
            timingCategory = TimingCategoryService.TimingCategories.FirstOrDefault(tc => tc.Id == id);
            DeleteConfirmation.Show();
        }
        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                var response = await TimingCategoryService.Delete(timingCategory.Id);
                if (response.IsFailure)
                {
                    await DialogService.ShowMessageBox(
                            UserMessages.Error,
                            response.Error.Message,
                            options: new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = false });
                }
                else
                {
                    Snackbar.Configuration.VisibleStateDuration = 3000;
                    Snackbar.Add(UserMessages.DeletionSuccess, Severity.Success);
                    await TimingCategoryService.GetTimingCategories();
                }
            }
        }
    }
}
