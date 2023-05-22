using ShuttleServiceManagementApp.Domain.Errors;
using ShuttleServiceManagementApp.Domain.Infrastructure;
using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Domain.ValueObjects;

namespace ShuttleServiceManagementApp.Domain.Entities
{
    public sealed class Bus : BaseEntity
    {
        private Bus(Guid id, DriverName driverName, int capacity)
        {
            Id = id;
            DriverName = driverName;
            Capacity = capacity;
        }

        public DriverName DriverName { get; set; }
        public int Capacity { get; set; }

        public static Result<Bus> Create(DriverName driverName, int capacity)
        {
            if (capacity == 0)
                return Result.Failure<Bus>(DomainErrors.Bus.Capacity.Required);
            return new Bus(new Guid(), driverName, capacity);
        }

    }
}
