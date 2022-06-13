using Housing.Data.Programmability;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Data.Configuration
{
    public class SummaryConfiguration : IEntityTypeConfiguration<Summary>
    {
        public void Configure(EntityTypeBuilder<Summary> builder)
        {
            builder.ToView("summaries", Constants.BillsSchema);
            builder.HasNoKey();

            builder.Property(name => name.TotalWithoutRent).HasColumnName("total_wo_rent");
        }
    }
}
