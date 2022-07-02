using Housing.Data;
using Housing.Services.Queries.Bills.Dto;
using Housing.Services.Queries.Summary.Dto;
using Housing.Services.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Services.Queries.Bills
{
    public class GetSummaryQuery : RequestDto, IRequest<SummaryDto>
    {
        public GetSummaryQuery(int year, int month, ReportType? type)
            : base(year, month, type) { }

        private class GetSummaryHandler : IRequestHandler<GetSummaryQuery, SummaryDto>
        {
            private readonly HousingContext context;

            public GetSummaryHandler(HousingContext context)
            {
                this.context = context;
            }

            public async Task<SummaryDto> Handle(GetSummaryQuery request, CancellationToken cancellationToken)
            {
                var result = await context.GetSummary(request.Date, request.EndDate, request.PreviousDate, request.PreviousEndDate)
                    .FirstOrDefaultAsync(cancellationToken);

                return new SummaryDto
                {
                    TotalRent = new ValueDto(result.TotalRent, result.TotalRentDiff),
                    TotalWithoutRent = new ValueDto(result.TotalWithoutRent, result.TotalWithoutRentDiff)
                };
            }
        }
    }
}
