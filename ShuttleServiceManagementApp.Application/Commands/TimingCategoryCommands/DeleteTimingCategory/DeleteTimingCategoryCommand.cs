using ShuttleServiceManagementApp.Application.Abstractions.Messaging;

namespace ShuttleServiceManagementApp.Application.Commands.TimingCategoryCommands.DeleteTimingCategory
{
    public sealed record DeleteTimingCategoryCommand(Guid timingCategoryId) : ICommand;
}
