using Housing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Data.Configuration
{
    public class HeatingConfiguration : IEntityTypeConfiguration<HeatingBill>
    {
        public void Configure(EntityTypeBuilder<HeatingBill> builder)
        {
            builder.ToTable("Heating", Constants.BillsSchema);
            builder.HasKey(k => k.BillingId);

            builder.HasOne(name => name.Billing)
                .WithOne(name => name.HeatingBill)
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
