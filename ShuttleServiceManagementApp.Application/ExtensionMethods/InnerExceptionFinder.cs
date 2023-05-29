namespace ShuttleServiceManagementApp.Application.ExtensionMethods
{
    internal static class InnerExceptionFcinder
    {
        internal static Exception FindInnerException(this Exception exception)
        {
            if (exception.InnerException is null)
                return exception;
            return FindInnerException(exception.InnerException);
        }
    }
}
