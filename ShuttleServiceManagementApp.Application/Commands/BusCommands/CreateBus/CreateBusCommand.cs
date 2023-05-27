using ShuttleServiceManagementApp.Application.Abstractions.Messaging;

namespace ShuttleServiceManagementApp.Application.Commands.BusCommands.CreateBus
{
    public sealed record CreateBusCommand(string DriverName, int Capacity) : ICommand<Guid>;
}
