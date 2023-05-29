using ShuttleServiceManagementApp.Application.Abstractions.Messaging;
using ShuttleServiceManagementApp.Domain.DataAccess.Repositories;
using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Application.Queries.TimingCategoryQueries.GetAllTimingCategories
{
    public class GetTimingCategoriesQueryHandler : IQueryHandler<GetTimingCategoriesQuery, List<TimingCategoryResponse>>
    {
        private readonly ITimingCategoryRepository _timingCategoryRepository;

        public GetTimingCategoriesQueryHandler(ITimingCategoryRepository timingCategoryRepository)
        {
            _timingCategoryRepository = timingCategoryRepository;
        }
        public async Task<Result<List<TimingCategoryResponse>>> Handle(GetTimingCategoriesQuery request, CancellationToken cancellationToken)
        {
            var timingCategories = await _timingCategoryRepository.GetAll(cancellationToken);
            var response = new List<TimingCategoryResponse>();
            foreach (var timingCategory in timingCategories)
                response.Add(new TimingCategoryResponse
                {
                    Id = timingCategory.Id,
                    Title = timingCategory.Title.Value
                });
            return response;
        }
    }
}
