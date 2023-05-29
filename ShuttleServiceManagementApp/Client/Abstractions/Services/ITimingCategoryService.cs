using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Shared.Requests;
using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Client.Abstractions.Services
{
    public interface ITimingCategoryService
    {
        List<TimingCategoryResponse> TimingCategories { get; set; }
        event Action TimingCategoriesChanged;

        Task<Result<Guid>> CreateTimingCategory(RegisterTimingCategoryRequest timingCategory);
        Task<Result<Guid>> Delete(Guid id);
        Task GetTimingCategories();
    }
}
