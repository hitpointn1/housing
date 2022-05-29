using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;

namespace Housing.Services.Queries
{
    public class GetWaterBillQuery : RequestDto, IRequest<WaterBillDto>
    {
        public GetWaterBillQuery(string year, string month, ReportType? type) : base(year, month, type)
        {
        }

        private class GetWaterBillHandler : IRequestHandler<GetWaterBillQuery, WaterBillDto>
        {
            public Task<WaterBillDto> Handle(GetWaterBillQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new WaterBillDto
                {
                    Payment = new(600, -300),
                    ColdReadings = new(null, null, 356),
                    HotReadings = new(235, 7),
                    PreviousColdReadings = new(350, 5),
                    PreviousHotReadings = new(228, 6)
                });
            }
        }
    }
}
