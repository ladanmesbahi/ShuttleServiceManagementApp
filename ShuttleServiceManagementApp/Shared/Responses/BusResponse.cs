namespace ShuttleServiceManagementApp.Shared.Responses
{
	//public sealed record BusResponse(Guid Id, string DriverName, int Capacity);
	public sealed class BusResponse
	{
		public BusResponse()
		{
		}

		public BusResponse(Guid id, string driverName, int capacity)
		{
			Id = id;
			DriverName = driverName;
			Capacity = capacity;
		}

		public Guid Id { get; set; }
		public string DriverName { get; set; }
		public int Capacity { get; set; }
	}
}
