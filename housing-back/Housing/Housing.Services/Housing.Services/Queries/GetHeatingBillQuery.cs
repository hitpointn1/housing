using Housing.Data.Entities;
using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;

namespace Housing.Services.Queries
{
    public class GetHeatingBillQuery : RequestDto, IRequest<PaymentDto>
    {
        public GetHeatingBillQuery(string year, string month, ReportType? type)
            : base(year, month, type) { }

        private class GetHeatingBillHandler : IRequestHandler<GetHeatingBillQuery, PaymentDto>
        {
            private readonly PaymentRetrievalTemplate _template;

            public GetHeatingBillHandler(PaymentRetrievalTemplate template)
            {
                _template = template;
            }

            public Task<PaymentDto> Handle(GetHeatingBillQuery request, CancellationToken cancellationToken)
            {
                return _template.Get<HeatingBill>(request, cancellationToken);
            }
        }
    }
}
