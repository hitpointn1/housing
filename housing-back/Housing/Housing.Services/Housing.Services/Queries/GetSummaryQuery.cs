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
                return Task.FromResult(new SummaryDto { TotalRent = new(13000), TotalWithoutRent = new(3476, -250) });
            }
        }
    }
}
