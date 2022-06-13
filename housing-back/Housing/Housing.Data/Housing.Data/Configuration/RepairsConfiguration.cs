using Housing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Data.Configuration
{
    public class RepairsConfiguration : IEntityTypeConfiguration<RepairsBill>
    {
        public void Configure(EntityTypeBuilder<RepairsBill> builder)
        {
            builder.ToTable("Repairs", Constants.BillsSchema);
            builder.HasKey(k => k.BillingId);

            builder.HasOne(name => name.Billing)
                .WithOne(name => name.RepairsBill)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.Property(name => name.BillingId)
                .ValueGeneratedNever();

            builder.Property(name => name.Payment)
               .HasPrecision(18, 2)
               .HasDefaultValue(0);
        }
    }
}
