using Housing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlTypes;

namespace Housing.Data.Configuration
{
    public class BillingConfiguration : IEntityTypeConfiguration<Billing>
    {
        public void Configure(EntityTypeBuilder<Billing> builder)
        {
            builder.ToTable("billing", Constants.BillsSchema);
            builder.HasKey(k => k.Id);

            builder.Property(k => k.Date).HasColumnType(NpgsqlDbType.Date.ToString());
            builder.Property(k => k.Appartments).HasMaxLength(450);
        }
    }
}
