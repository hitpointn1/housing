using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;

namespace Housing.Services.Queries
{
    public class GetElectricityBillQuery : RequestDto, IRequest<ElectricityBillDto>
    {
        public GetElectricityBillQuery(string year, string month, ReportType? type)
            : base(year, month, type) { }

        private class GetElectricityBillHandler : IRequestHandler<GetElectricityBillQuery, ElectricityBillDto>
        {
            public Task<ElectricityBillDto> Handle(GetElectricityBillQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new ElectricityBillDto
                {
                    Payment = new(843, -50),
                    ConsumptionReadings = new(10238, 228),
                    PreviousConsumptionReadings = new(10048, 183)
                });
            }
        }
    }
}
