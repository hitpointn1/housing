using Housing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Data.Configuration
{
    public class AdditionalsConfiguration : IEntityTypeConfiguration<AdditionalsBill>
    {
        public void Configure(EntityTypeBuilder<AdditionalsBill> builder)
        {
            builder.ToTable("additionals", Constants.BillsSchema);
            builder.HasKey(k => k.BillingId);

            builder.HasOne(name => name.Billing)
                .WithOne(name => name.Additionals)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.Property(name => name.BillingId)
                .ValueGeneratedNever();

            builder.Property(name => name.Internet)
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            builder.Property(name => name.Payment)
               .HasPrecision(18, 2)
               .HasDefaultValue(0);
        }
    }
}
