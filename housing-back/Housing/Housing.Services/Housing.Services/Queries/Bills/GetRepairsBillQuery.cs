using Housing.Data.Entities;
using Housing.Services.Queries.Bills.Dto;
using Housing.Services.Enums;
using MediatR;

namespace Housing.Services.Queries.Bills
{
    public class GetRepairsBillQuery : RequestDto, IRequest<PaymentDto>
    {
        public GetRepairsBillQuery(int year, int month, ReportType? type)
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
