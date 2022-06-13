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
    public class GetAdditionalBillsQuery : RequestDto, IRequest<AdditionalsBillDto>
    {
        public GetAdditionalBillsQuery(string year, string month, ReportType? type)
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
                    Internet = new ValueDto(rangeGroup.Internet, MathHelper.Diff(rangeGroup.Internet, previousGroup.Internet), rangeGroup.InternetAVG),
                    Payment = new ValueDto(rangeGroup.Payment, MathHelper.Diff(rangeGroup.Payment, previousGroup.Payment), rangeGroup.PaymentAVG),
                };
            }
        }
    }
}
