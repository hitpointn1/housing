using Housing.Data.Entities;
using Housing.Services.Enums;
using Housing.Services.Queries.Bills.Dto;
using MediatR;

namespace Housing.Services.Queries.Bills
{
    public class GetHeatingBillQuery : RequestDto, IRequest<PaymentDto>
    {
        public GetHeatingBillQuery(int year, int month, ReportType? type)
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
