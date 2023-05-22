namespace ShuttleServiceManagementApp.Domain.Infrastructure
{
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        public Guid Id { get; set; }

        protected BaseEntity(Guid id)
        {
            Id = id;
        }
        protected BaseEntity()
        {

        }

        public bool Equals(BaseEntity? other)
        {
            return other != null && other.GetType() == GetType() && Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            return obj != null && obj is BaseEntity entity && Equals(entity);
        }

        public override int GetHashCode() => Id.GetHashCode() * 41;
    }
}
