using ShuttleServiceManagementApp.Application.Abstractions.Messaging;

namespace ShuttleServiceManagementApp.Application.Commands.TimingCategoryCommands.CreateTimingCategory
{
    public sealed record CreateTimingCategoryCommand(string title) : ICommand<Guid>;
}
