using ShuttleServiceManagementApp.Domain.Errors;
using ShuttleServiceManagementApp.Domain.Infrastructure;
using ShuttleServiceManagementApp.Domain.Shared;

namespace ShuttleServiceManagementApp.Domain.ValueObjects
{
    public sealed class Title : ValueObject
    {
        public const int MaxLength = 50;
        public string Value { get; }

        private Title(string value)
        {
            Value = value;
        }

        public static Result<Title> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Title>(DomainErrors.Name.Empty);
            if (value.Length > MaxLength)
                return Result.Failure<Title>(DomainErrors.Name.MaxLength);
            return new Title(value);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
