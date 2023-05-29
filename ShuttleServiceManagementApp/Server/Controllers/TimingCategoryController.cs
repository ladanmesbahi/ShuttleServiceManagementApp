using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShuttleServiceManagementApp.Application.Commands.TimingCategoryCommands.CreateTimingCategory;
using ShuttleServiceManagementApp.Application.Commands.TimingCategoryCommands.DeleteTimingCategory;
using ShuttleServiceManagementApp.Application.Queries.TimingCategoryQueries.GetAllTimingCategories;
using ShuttleServiceManagementApp.Server.Abstractions;
using ShuttleServiceManagementApp.Shared.Requests;

namespace ShuttleServiceManagementApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimingCategoryController : ApiController
    {
        public TimingCategoryController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var request = new GetTimingCategoriesQuery();
            var response = await Sender.Send(request, cancellationToken);
            return Ok(response.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterTimingCategoryRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateTimingCategoryCommand(request.Title);
            var result = await Sender.Send(command, cancellationToken);
            if (result.IsSuccess)
                return Ok(result.Value);
            return BadRequest(result.Error);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteTimingCategoryCommand(id);
            var result = await Sender.Send(command, cancellationToken);
            if (result.IsSuccess)
                return Ok(id);
            return BadRequest(result.Error);
        }

    }
}
