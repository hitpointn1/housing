using Housing.Data;
using Housing.Data.Entities;
using Housing.Data.Helpers;
using Housing.Services.Enums;
using Housing.Services.Queries.Bills.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Services.Queries.Bills
{
    public class GetElectricityBillQuery : RequestDto, IRequest<ElectricityBillDto>
    {
        public GetElectricityBillQuery(int year, int month, ReportType? type)
            : base(year, month, type) { }

        private class GetElectricityBillHandler : IRequestHandler<GetElectricityBillQuery, ElectricityBillDto>
        {
            private readonly HousingContext context;

            public GetElectricityBillHandler(HousingContext context)
            {
                this.context = context;
            }

            public async Task<ElectricityBillDto> Handle(GetElectricityBillQuery request, CancellationToken cancellationToken)
            {
                var current = await context.Set<ElectricityBill>()
                    .Aggregate(request.Date, request.EndDate)
                    .SingleOrDefaultAsync(cancellationToken);

                var previous = await context.Set<ElectricityBill>()
                    .Aggregate(request.PreviousDate, request.PreviousEndDate)
                    .SingleOrDefaultAsync(cancellationToken);

                return new ElectricityBillDto
                {
                    Payment = new ValueDto(
                        current.Payment,
                        current.Payment.Diff(previous.Payment),
                        current.PaymentAVG
                    ),
                    ConsumptionReadings = new ValueDto(
                        current.ConsumptionReadings,
                        current.ConsumptionReadings.Diff(previous.ConsumptionReadings),
                        current.ConsumptionPrediction(previous)
                    )
                };
            }
        }
    }
}
