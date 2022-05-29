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
            public Task<PaymentDto> Handle(GetHeatingBillQuery request, CancellationToken cancellationToken)
            {
                return new PaymentRetrievalTemplate().Get(request);
            }
        }
    }
}
