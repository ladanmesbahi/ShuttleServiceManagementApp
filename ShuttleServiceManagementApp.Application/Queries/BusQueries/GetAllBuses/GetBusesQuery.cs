using ShuttleServiceManagementApp.Application.Abstractions.Messaging;
using ShuttleServiceManagementApp.Shared.Responses;

namespace ShuttleServiceManagementApp.Application.Queries.BusQueries.GetAllBuses
{
	public sealed record GetBusesQuery() : IQuery<List<BusResponse>>;
}
