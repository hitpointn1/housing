using Housing.Data;
using Housing.Data.Entities;
using Housing.Data.Helpers;
using Housing.Services.Queries.Bills.Dto;
using Housing.Services.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Services.Queries.Bills
{
    public class GetWaterBillQuery : RequestDto, IRequest<WaterBillDto>
    {
        public GetWaterBillQuery(int year, int month, ReportType? type) : base(year, month, type)
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

                return new WaterBillDto
                {
                    Payment = new ValueDto(
                        current.Payment,
                        current.Payment.Diff(previous.Payment),
                        current.PaymentAVG
                    ),
                    ColdReadings = new ValueDto(
                        current.ColdReadings,
                        current.ColdReadings.Diff(previous.ColdReadings),
                        current.ColdPrediction(previous)
                    ),
                    HotReadings = new ValueDto(
                        current.HotReadings,
                        current.HotReadings.Diff(previous.HotReadings),
                        current.HotPrediction(previous)
                    )
                };
            }
        }
    }
}
