using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;

namespace Housing.Services.Queries
{
    public class GetSummaryQuery : RequestDto, IRequest<SummaryDto>
    {
        public GetSummaryQuery(string year, string month, ReportType? type)
            : base(year, month, type) { }

        private class GetSummaryHandler : IRequestHandler<GetSummaryQuery, SummaryDto>
        {
            public Task<SummaryDto> Handle(GetSummaryQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new SummaryDto() { TotalRent = 13000, TotalWithoutRent = 3476 });
            }
        }
    }
}
