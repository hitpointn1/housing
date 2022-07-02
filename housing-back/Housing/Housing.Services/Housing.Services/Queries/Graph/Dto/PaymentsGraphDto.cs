using Housing.Data.Helpers;

namespace Housing.Services.Queries.Graph.Dto
{
    public class PaymentsGraphDto
    {
        public PaymentsGraphDto()
        {
            Electricity = new decimal?[DateHelper.MONTH_NUMBER];
            Additionals = new decimal?[DateHelper.MONTH_NUMBER];
            Internet = new decimal?[DateHelper.MONTH_NUMBER];
            Water = new decimal?[DateHelper.MONTH_NUMBER];
            Rent = new decimal?[DateHelper.MONTH_NUMBER];
            Repairs = new decimal?[DateHelper.MONTH_NUMBER];
            Heating = new decimal?[DateHelper.MONTH_NUMBER];
        }

        public decimal?[] Electricity { get; set; }
        public decimal?[] Additionals { get; set; }
        public decimal?[] Internet { get; set; }
        public decimal?[] Water { get; set; }
        public decimal?[] Rent { get; set; }
        public decimal?[] Repairs { get; set; }
        public decimal?[] Heating { get; set; }
    }
}
