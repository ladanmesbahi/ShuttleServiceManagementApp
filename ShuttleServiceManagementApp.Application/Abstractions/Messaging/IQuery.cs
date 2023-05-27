using MediatR;
using ShuttleServiceManagementApp.Domain.Shared;

namespace ShuttleServiceManagementApp.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
