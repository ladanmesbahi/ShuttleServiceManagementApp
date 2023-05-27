using ShuttleServiceManagementApp.Application.Abstractions.Messaging;
using ShuttleServiceManagementApp.Domain.DataAccess;
using ShuttleServiceManagementApp.Domain.DataAccess.Repositories;
using ShuttleServiceManagementApp.Domain.Exceptions;
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
			var bus = await _busRepository.GetById(request.BusId);
			if (bus == null)
				throw new BusNotFoundException();
			await _busRepository.Delete(bus);
			await _unitOfWork.Complete();
			return Result.Success();
		}
	}
}
