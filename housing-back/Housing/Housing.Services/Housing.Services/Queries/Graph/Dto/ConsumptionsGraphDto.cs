using Housing.Data.Helpers;

namespace Housing.Services.Queries.Graph.Dto
{
    public class ConsumptionsGraphDto
    {
        public ConsumptionsGraphDto()
        {
            Electricity = new int?[DateHelper.MONTH_NUMBER];
            Cold = new int?[DateHelper.MONTH_NUMBER];
            Hot = new int?[DateHelper.MONTH_NUMBER];
        }

        public int?[] Electricity { get; set; }
        public int?[] Cold { get; set; }
        public int?[] Hot { get; set; }
    }
}
