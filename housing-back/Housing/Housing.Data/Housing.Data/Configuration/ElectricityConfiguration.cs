using Housing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Data.Configuration
{
    public class ElectricityConfiguration : IEntityTypeConfiguration<ElectricityBill>
    {
        public void Configure(EntityTypeBuilder<ElectricityBill> builder)
        {
            builder.ToTable("electricity", Constants.BillsSchema);
            builder.HasKey(k => k.BillingId);

            builder.HasOne(name => name.Billing)
                .WithOne(name => name.ElectricityBill)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.Property(name => name.BillingId)
                .ValueGeneratedNever();

            builder.Property(name => name.Payment)
               .HasPrecision(18, 2)
               .HasDefaultValue(0);

            builder.Property(name => name.ConsumptionReadings).HasMaxLength(10);
        }
    }
}
