using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleServiceManagementApp.Domain.Constants;
using ShuttleServiceManagementApp.Domain.Entities;
using ShuttleServiceManagementApp.Domain.ValueObjects;
using ShuttleServiceManagementApp.Persistence.Constants;

namespace ShuttleServiceManagementApp.Persistence.Configurations
{
    public class TimingCategoryConfiguration : IEntityTypeConfiguration<TimingCategory>
    {
        public void Configure(EntityTypeBuilder<TimingCategory> builder)
        {
            builder.ToTable(TableNames.TimingCategories);

            builder.Property(x => x.Title)
                .HasMaxLength(Title.MaxLength)
                .HasConversion(x => x.Value, v => Title.Create(v).Value);

            builder.HasIndex(tc => tc.Title)
                .IsUnique()
                .HasDatabaseName(IndexNames.UK_TimingCategory_Title);
        }
    }
}
