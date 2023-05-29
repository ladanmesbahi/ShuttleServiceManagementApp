using ShuttleServiceManagementApp.Application.Abstractions.Messaging;
using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Application.Queries.TimingCategoryQueries.GetAllTimingCategories
{
    public sealed record GetTimingCategoriesQuery : IQuery<List<TimingCategoryResponse>>;
}
