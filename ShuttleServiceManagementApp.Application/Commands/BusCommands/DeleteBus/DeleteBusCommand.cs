using ShuttleServiceManagementApp.Application.Abstractions.Messaging;

namespace ShuttleServiceManagementApp.Application.Commands.BusCommands.DeleteBus
{
	public sealed record DeleteBusCommand(Guid BusId) : ICommand;
}
