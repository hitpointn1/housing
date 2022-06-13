using Housing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Data.Configuration
{
    public class WaterConfiguration : IEntityTypeConfiguration<WaterBill>
    {
        public void Configure(EntityTypeBuilder<WaterBill> builder)
        {
            builder.ToTable("water", Constants.BillsSchema);
            builder.HasKey(k => k.BillingId);

            builder.HasOne(name => name.Billing)
                .WithOne(name => name.WaterBill)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.Property(name => name.BillingId)
                .ValueGeneratedNever();

            builder.Property(name => name.Payment)
               .HasPrecision(18, 2)
               .HasDefaultValue(0);

            builder.Property(name => name.ColdReadings).HasMaxLength(10);
            builder.Property(name => name.HotReadings).HasMaxLength(10);
        }
    }
}
