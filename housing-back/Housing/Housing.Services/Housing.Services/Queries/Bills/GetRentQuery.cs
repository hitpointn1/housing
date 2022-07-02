using Housing.Data.Entities;
using Housing.Services.Queries.Bills.Dto;
using Housing.Services.Enums;
using MediatR;

namespace Housing.Services.Queries.Bills
{
    public class GetRentQuery : RequestDto, IRequest<PaymentDto>
    {
        public GetRentQuery(int year, int month, ReportType? type)
            : base(year, month, type) { }

        private class GetRentHandler : IRequestHandler<GetRentQuery, PaymentDto>
        {
            private readonly PaymentRetrievalTemplate _template;

            public GetRentHandler(PaymentRetrievalTemplate template)
            {
                _template = template;
            }

            public Task<PaymentDto> Handle(GetRentQuery request, CancellationToken cancellationToken)
            {
                return _template.Get<Rent>(request, cancellationToken);
            }
        }
    }
}
