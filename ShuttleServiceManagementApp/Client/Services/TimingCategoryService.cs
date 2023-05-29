using ShuttleServiceManagementApp.Client.Abstractions.Services;
using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Shared.Requests;
using ShuttleServiceManagementApp.Shared.Responses;
using System.Net.Http.Json;

namespace ShuttleServiceManagementApp.Client.Services
{
    public class TimingCategoryService : ITimingCategoryService
    {
        private readonly HttpClient _httpClient;

        public TimingCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<TimingCategoryResponse> TimingCategories { get; set; }

        public event Action TimingCategoriesChanged;

        public async Task<Result<Guid>> CreateTimingCategory(RegisterTimingCategoryRequest timingCategory)
        {
            var response = await _httpClient.PostAsJsonAsync<RegisterTimingCategoryRequest>("/api/timingCategory", timingCategory);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Guid>();
            return Result.Failure<Guid>(await response.Content.ReadFromJsonAsync<Error>());
        }

        public async Task<Result<Guid>> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/api/timingCategory/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Guid>();
            return Result.Failure<Guid>(await response.Content.ReadFromJsonAsync<Error>());
        }

        public async Task GetTimingCategories()
        {
            TimingCategories = await _httpClient.GetFromJsonAsync<List<TimingCategoryResponse>>("/api/timingCategory");
            TimingCategoriesChanged.Invoke();
        }
    }
}
