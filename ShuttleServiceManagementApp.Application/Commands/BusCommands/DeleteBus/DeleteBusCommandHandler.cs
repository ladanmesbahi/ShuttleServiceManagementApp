using ShuttleServiceManagementApp.Application.Abstractions.Messaging;
using ShuttleServiceManagementApp.Application.ExtensionMethods;
using ShuttleServiceManagementApp.Domain.DataAccess;
using ShuttleServiceManagementApp.Domain.DataAccess.Repositories;
using ShuttleServiceManagementApp.Domain.Errors;
using ShuttleServiceManagementApp.Domain.Shared;

namespace ShuttleServiceManagementApp.Application.Commands.BusCommands.DeleteBus
{
	public class DeleteBusCommandHandler : ICommandHandler<DeleteBusCommand>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IBusRepository _busRepository;

		public DeleteBusCommandHandler(IUnitOfWork unitOfWork, IBusRepository busRepository)
		{
			_unitOfWork = unitOfWork;
			_busRepository = busRepository;
		}
		public async Task<Result> Handle(DeleteBusCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var bus = await _busRepository.GetById(request.BusId);
				if (bus == null)
					return Result.Failure(Domain.Errors.DomainErrors.Bus.NotFound);
				await _busRepository.Delete(bus);
				await _unitOfWork.Complete();
				return Result.Success();
			}
			catch (Exception ex)
			{
				var innerException = ex.FindInnerException();
				return Result.Failure(new(ErrorCodes.UnHandledException, ex.Message));
			}
		}
	}
}
