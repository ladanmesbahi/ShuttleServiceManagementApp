using Microsoft.AspNetCore.Components;

namespace ShuttleServiceManagementApp.Client.Components
{
	public class ConfirmBase : ComponentBase
	{
		protected bool ShowConfirmation { get; set; }

		[Parameter]
		public string ConfirmationTitle { get; set; } = "حذف";

		[Parameter]
		public string ConfirmationMessage { get; set; } = "آیا مطمئنید؟";

		public void Show()
		{
			ShowConfirmation = true;
			StateHasChanged();
		}

		[Parameter]
		public EventCallback<bool> ConfirmationChanged { get; set; }

		protected async Task OnConfirmationChange(bool value)
		{
			ShowConfirmation = false;
			await ConfirmationChanged.InvokeAsync(value);
		}

	}
}
