using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShuttleServiceManagementApp.Application.Commands.BusCommands.CreateBus;
using ShuttleServiceManagementApp.Application.Commands.BusCommands.DeleteBus;
using ShuttleServiceManagementApp.Application.Queries.BusQueries.GetAllBuses;
using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Server.Abstractions;
using ShuttleServiceManagementApp.Shared.Requests;
using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BusController : ApiController
	{
		public BusController(ISender sender) : base(sender)
		{
		}

		[HttpPost]
		public async Task<IActionResult> RegisterBus([FromBody] RegisterBusRequest request, CancellationToken cancellationToken)
		{
			var command = new CreateBusCommand(
				request.DriverName,
				request.Capacity);

			Result<Guid> result = await Sender.Send(command, cancellationToken);

			return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
		}

		[HttpGet]
		public async Task<IActionResult> GetBuses(CancellationToken cancellationToken)
		{
			var query = new GetBusesQuery();

			Result<List<BusResponse>> response = await Sender.Send(
				query,
				cancellationToken);

			return Ok(response.Value);
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
		{
			var command = new DeleteBusCommand(id);
			var result = await Sender.Send(command, cancellationToken);
			return result.IsSuccess ? Ok() : BadRequest(result.Error);
		}
	}
}
