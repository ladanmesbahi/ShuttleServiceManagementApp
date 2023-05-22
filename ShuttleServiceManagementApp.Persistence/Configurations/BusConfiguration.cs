using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleServiceManagementApp.Domain.Entities;
using ShuttleServiceManagementApp.Domain.ValueObjects;
using ShuttleServiceManagementApp.Persistence.Constants;

namespace ShuttleServiceManagementApp.Persistence.Configurations
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.ToTable(TableNames.Buses);

            builder.HasKey(b => b.Id);

            builder.Property(b => b.DriverName)
                .HasMaxLength(DriverName.MaxLength)
                .HasConversion(x => x.Value, v => DriverName.Create(v).Value);
        }
    }
}
