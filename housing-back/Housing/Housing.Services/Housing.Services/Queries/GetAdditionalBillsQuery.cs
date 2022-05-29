using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;

namespace Housing.Services.Queries
{
    public class GetAdditionalBillsQuery : RequestDto, IRequest<AdditionalsBillDto>
    {
        public GetAdditionalBillsQuery(string year, string month, ReportType? type)
            : base(year, month, type) { }

        private class GetAdditionalBillsHandler : IRequestHandler<GetAdditionalBillsQuery, AdditionalsBillDto>
        {
            public Task<AdditionalsBillDto> Handle(GetAdditionalBillsQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new AdditionalsBillDto
                {
                    Payment = new(1238, 113),
                    Internet = new(450)
                });
            }
        }
    }
}
