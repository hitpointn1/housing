using Housing.Data.Programmability;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Data.Configuration
{
    public class DetailedSummaryConfiguration : IEntityTypeConfiguration<DetailedSummary>
    {
        public void Configure(EntityTypeBuilder<DetailedSummary> builder)
        {
            builder.ToView("detailed_summaries", Constants.BillsSchema);
            builder.HasNoKey();

            builder.Property(name => name.TotalWithoutRent).HasColumnName("total_wo_rent");
            builder.Property(name => name.TotalWithoutRentDiff).HasColumnName("total_wo_rent_diff");
        }
    }
}
