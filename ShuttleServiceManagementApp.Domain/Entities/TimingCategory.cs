using ShuttleServiceManagementApp.Domain.Infrastructure;
using ShuttleServiceManagementApp.Domain.Shared;
using ShuttleServiceManagementApp.Domain.ValueObjects;

namespace ShuttleServiceManagementApp.Domain.Entities
{
	public class TimingCategory : BaseEntity
	{
		private TimingCategory(Guid id, Title title)
		{
			Id = id;
			Title = title;
		}
		public Title Title { get; set; }
		public static Result<TimingCategory> Create(Title name)
		{
			return new TimingCategory(new Guid(), name);
		}
	}
}
