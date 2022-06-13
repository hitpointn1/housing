using Housing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Data.Configuration
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable(nameof(Rent), Constants.BillsSchema);
            builder.HasKey(k => k.BillingId);

            builder.HasOne(name => name.Billing)
                .WithOne(name => name.Rent)
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
