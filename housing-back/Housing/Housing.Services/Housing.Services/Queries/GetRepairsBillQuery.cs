using Housing.Data.Entities;
using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;

namespace Housing.Services.Queries
{
    public class GetRepairsBillQuery : RequestDto, IRequest<PaymentDto>
    {
        public GetRepairsBillQuery(string year, string month, ReportType? type)
            : base(year, month, type) { }

        private class GetRepairsBillHandler : IRequestHandler<GetRepairsBillQuery, PaymentDto>
        {
            private readonly PaymentRetrievalTemplate _template;

            public GetRepairsBillHandler(PaymentRetrievalTemplate template)
            {
                _template = template;
            }

            public Task<PaymentDto> Handle(GetRepairsBillQuery request, CancellationToken cancellationToken)
            {
                return _template.Get<RepairsBill>(request, cancellationToken);
            }
        }
    }
}
