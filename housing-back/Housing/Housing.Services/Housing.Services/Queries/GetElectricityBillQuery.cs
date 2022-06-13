using Housing.Data;
using Housing.Data.Entities;
using Housing.Data.Helpers;
using Housing.Services.Helpers;
using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Services.Queries
{
    public class GetElectricityBillQuery : RequestDto, IRequest<ElectricityBillDto>
    {
        public GetElectricityBillQuery(string year, string month, ReportType? type)
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

                var paymentDiff = MathHelper.Diff(current.Payment, previous.Payment);
                var consumptionDiff = MathHelper.Diff(current.ConsumptionReadings, previous.ConsumptionReadings);
                var consumptionPrediction = MathHelper.Prediction(current.ConsumptionReadings, previous.ConsumptionReadingsMin, current.ConsumptionReadingsCount, previous.ConsumptionReadingsCount);

                return new ElectricityBillDto
                {
                    Payment = new ValueDto(current.Payment, paymentDiff, current.PaymentAVG),
                    ConsumptionReadings = new ValueDto(current.ConsumptionReadings, consumptionDiff, consumptionPrediction)
                };
            }
        }
    }
}
