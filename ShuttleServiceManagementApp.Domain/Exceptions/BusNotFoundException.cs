using ShuttleServiceManagementApp.Domain.Errors;

namespace ShuttleServiceManagementApp.Domain.Exceptions
{
	public class BusNotFoundException : DomainException
	{
		public BusNotFoundException() : base(DomainErrors.Bus.NotFound.Message)
		{
		}
	}
}
