using ShuttleServiceManagementApp.Client.Messages;
using ShuttleServiceManagementApp.Shared.Requests;

namespace ShuttleServiceManagementApp.Client.Pages.TimingCategory
{
    public partial class CreateTimingCategory
    {
        RegisterTimingCategoryRequest timingCategory = new RegisterTimingCategoryRequest();
        async Task AddTimingCategory()
        {
            var response = await TimingCategoryService.CreateTimingCategory(timingCategory);
            if (response.IsFailure)
            {
                await DialogService.ShowMessageBox(
                        UserMessages.Error,
                        response.Error.Message,
                        options: new MudBlazor.DialogOptions { MaxWidth = MudBlazor.MaxWidth.Medium, FullWidth = false });
            }
            else
                NavigationManager.NavigateTo("/timingCategoryList");
        }
    }
}
