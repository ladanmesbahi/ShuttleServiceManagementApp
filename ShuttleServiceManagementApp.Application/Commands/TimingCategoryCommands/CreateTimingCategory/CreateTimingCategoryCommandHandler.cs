using ShuttleServiceManagementApp.Application.Abstractions.Messaging;
using ShuttleServiceManagementApp.Application.ExtensionMethods;
using ShuttleServiceManagementApp.Domain.Constants;
using ShuttleServiceManagementApp.Domain.DataAccess;
using ShuttleServiceManagementApp.Domain.DataAccess.Repositories;
using ShuttleServiceManagementApp.Domain.Entities;
using ShuttleServiceManagementApp.Domain.Errors;
using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Domain.ValueObjects;

namespace ShuttleServiceManagementApp.Application.Commands.TimingCategoryCommands.CreateTimingCategory
{
    public class CreateTimingCategoryCommandHandler : ICommandHandler<CreateTimingCategoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITimingCategoryRepository _timingCategoryRepository;
        public CreateTimingCategoryCommandHandler(IUnitOfWork unitOfWork, ITimingCategoryRepository timingCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _timingCategoryRepository = timingCategoryRepository;
        }

        public async Task<Result<Guid>> Handle(CreateTimingCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var titleResult = Title.Create(request.title);
                if (titleResult.IsFailure)
                    return Result.Failure<Guid>(titleResult.Error);
                var timingCategory = TimingCategory.Create(titleResult.Value);
                if (timingCategory.IsFailure)
                    return Result.Failure<Guid>(timingCategory.Error);
                await _timingCategoryRepository.Add(timingCategory.Value);
                await _unitOfWork.Complete();
                return Result.Success<Guid>(timingCategory.Value.Id);
            }
            catch (Exception ex)
            {
                var innerException = ex.FindInnerException();
                if (innerException.Message.Contains(IndexNames.UK_TimingCategory_Title))
                    return Result.Failure<Guid>(DomainErrors.TimingCategory.Title.Repeated);
                return Result.Failure<Guid>(new Error(ErrorCodes.UnHandledException, innerException.Message));
            }
        }
    }
}
