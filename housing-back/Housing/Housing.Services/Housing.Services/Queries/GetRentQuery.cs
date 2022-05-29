using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;

namespace Housing.Services.Queries
{
    public class GetRentQuery : RequestDto, IRequest<PaymentDto>
    {
        public GetRentQuery(string year, string month, ReportType? type)
            : base(year, month, type) { }

        private class GetRentHandler : IRequestHandler<GetRentQuery, PaymentDto>
        {
            public Task<PaymentDto> Handle(GetRentQuery request, CancellationToken cancellationToken)
            {
                return new PaymentRetrievalTemplate().Get(request);
            }
        }
    }
}
