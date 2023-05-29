using ShuttleServiceManagementApp.Application.Abstractions.Messaging;
using ShuttleServiceManagementApp.Application.ExtensionMethods;
using ShuttleServiceManagementApp.Domain.Constants;
using ShuttleServiceManagementApp.Domain.DataAccess;
using ShuttleServiceManagementApp.Domain.DataAccess.Repositories;
using ShuttleServiceManagementApp.Domain.Entities;
using ShuttleServiceManagementApp.Domain.Errors;
using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Domain.ValueObjects;

namespace ShuttleServiceManagementApp.Application.Commands.BusCommands.CreateBus
{
	internal class CreateBusCommandHandler : ICommandHandler<CreateBusCommand, Guid>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IBusRepository _busRepository;

		public CreateBusCommandHandler(IUnitOfWork unitOfWork, IBusRepository busRepository)
		{
			_unitOfWork = unitOfWork;
			_busRepository = busRepository;
		}
		public async Task<Result<Guid>> Handle(CreateBusCommand request, CancellationToken cancellationToken)
		{
			try
			{
				Result<DriverName> driverNameResult = DriverName.Create(request.DriverName);
				if (driverNameResult.IsFailure)
					return Result.Failure<Guid>(driverNameResult.Error);

				Result<Bus> bus = Bus.Create(driverNameResult.Value, request.Capacity);
				if (bus.IsFailure)
					return Result.Failure<Guid>(bus.Error);

				await _busRepository.Add(bus.Value);
				await _unitOfWork.Complete();
				return Result.Success(bus.Value.Id);
			}
			catch (Exception ex)
			{
				var innerException = ex.FindInnerException();
				if (innerException.Message.Contains(IndexNames.UK_Bus_DriverName))
					return Result.Failure<Guid>(DomainErrors.Bus.DriverName.Repeated);
				return Result.Failure<Guid>(new(ErrorCodes.UnHandledException, innerException.Message));
			}
		}
	}
}
