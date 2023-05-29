using ShuttleServiceManagementApp.Application.Abstractions.Messaging;
using ShuttleServiceManagementApp.Application.ExtensionMethods;
using ShuttleServiceManagementApp.Domain.DataAccess;
using ShuttleServiceManagementApp.Domain.DataAccess.Repositories;
using ShuttleServiceManagementApp.Domain.Errors;
using ShuttleServiceManagementApp.Domain.Shared;

namespace ShuttleServiceManagementApp.Application.Commands.TimingCategoryCommands.DeleteTimingCategory
{
    public class DeleteTimingCategoryCommandHandler : ICommandHandler<DeleteTimingCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITimingCategoryRepository _timingCategoryRepository;

        public DeleteTimingCategoryCommandHandler(IUnitOfWork unitOfWork, ITimingCategoryRepository timingCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _timingCategoryRepository = timingCategoryRepository;
        }
        public async Task<Result> Handle(DeleteTimingCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var timingCategory = await _timingCategoryRepository.GetById(request.timingCategoryId, cancellationToken);
                if (timingCategory is null)
                    return Result.Failure(DomainErrors.TimingCategory.NotFound);
                await _timingCategoryRepository.Delete(timingCategory);
                await _unitOfWork.Complete();
                return Result.Success();
            }
            catch (Exception ex)
            {
                var innerException = ex.FindInnerException();
                return Result.Failure(new Error(ErrorCodes.UnHandledException, innerException.Message));
            }
        }
    }
}
