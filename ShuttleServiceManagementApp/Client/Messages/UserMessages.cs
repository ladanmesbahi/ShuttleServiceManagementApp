namespace ShuttleServiceManagementApp.Client.Messages
{
	internal static class UserMessages
	{
		internal static readonly string DeletionSuccess = "حذف با موفقیت انجام شد.";
		internal static readonly string Error = "خطا";
		internal static string DeleteConfirmation(string entityName) => $"آیا از حذف '{entityName}' مطمئنید؟";
	}
}
