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
    public class GetWaterBillQuery : RequestDto, IRequest<WaterBillDto>
    {
        public GetWaterBillQuery(string year, string month, ReportType? type) : base(year, month, type)
        {
        }

        private class GetWaterBillHandler : IRequestHandler<GetWaterBillQuery, WaterBillDto>
        {
            private readonly HousingContext context;

            public GetWaterBillHandler(HousingContext context)
            {
                this.context = context;
            }

            public async Task<WaterBillDto> Handle(GetWaterBillQuery request, CancellationToken cancellationToken)
            {
                var current = await context.Set<WaterBill>()
                    .Aggregate(request.Date, request.EndDate)
                    .SingleOrDefaultAsync(cancellationToken);

                var previous = await context.Set<WaterBill>()
                    .Aggregate(request.PreviousDate, request.PreviousEndDate)
                    .SingleOrDefaultAsync(cancellationToken);

                var paymentDiff = MathHelper.Diff(current.Payment, previous.Payment);
                var coldDiff = MathHelper.Diff(current.ColdReadings, previous.ColdReadings);
                var coldPrediction = MathHelper.Prediction(current.ColdReadings, previous.ColdReadingsMin, current.ReadingsCount, previous.ReadingsCount);
                var hotDiff = MathHelper.Diff(current.HotReadings, previous.HotReadings);
                var hotPrediction = MathHelper.Prediction(current.HotReadings, previous.HotReadingsMin, current.ReadingsCount, previous.ReadingsCount);

                return new WaterBillDto
                {
                    Payment = new ValueDto(current.Payment, paymentDiff, current.PaymentAVG),
                    ColdReadings = new ValueDto(current.ColdReadings, coldDiff, coldPrediction),
                    HotReadings = new ValueDto(current.HotReadings, hotDiff, hotPrediction)
                };
            }
        }
    }
}
