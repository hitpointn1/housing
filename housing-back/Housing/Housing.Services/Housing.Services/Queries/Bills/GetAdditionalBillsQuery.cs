using Housing.Data;
using Housing.Data.Entities;
using Housing.Data.Helpers;
using Housing.Services.Enums;
using Housing.Services.Queries.Bills.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Services.Queries.Bills
{
    public class GetAdditionalBillsQuery : RequestDto, IRequest<AdditionalsBillDto>
    {
        public GetAdditionalBillsQuery(int year, int month, ReportType? type)
            : base(year, month, type) { }

        private class GetAdditionalBillsHandler : IRequestHandler<GetAdditionalBillsQuery, AdditionalsBillDto>
        {
            private readonly HousingContext context;

            public GetAdditionalBillsHandler(HousingContext context)
            {
                this.context = context;
            }

            public async Task<AdditionalsBillDto> Handle(GetAdditionalBillsQuery request, CancellationToken cancellationToken)
            {
                var rangeGroup = await context.Set<AdditionalsBill>()
                    .Aggregate(request.Date, request.EndDate)
                    .SingleOrDefaultAsync(cancellationToken);

                var previousGroup = await context.Set<AdditionalsBill>()
                    .Aggregate(request.PreviousDate, request.PreviousEndDate)
                    .SingleOrDefaultAsync(cancellationToken);

                return new AdditionalsBillDto
                {
                    Internet = new ValueDto(
                        rangeGroup.Internet,
                        rangeGroup.Internet.Diff(previousGroup.Internet),
                        rangeGroup.InternetAVG
                    ),
                    Payment = new ValueDto(
                        rangeGroup.Payment,
                        rangeGroup.Payment.Diff(previousGroup.Payment),
                        rangeGroup.PaymentAVG
                    )
                };
            }
        }
    }
}
