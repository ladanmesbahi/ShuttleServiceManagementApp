using MediatR;
using ShuttleServiceManagementApp.Domain.Shared;

namespace ShuttleServiceManagementApp.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
