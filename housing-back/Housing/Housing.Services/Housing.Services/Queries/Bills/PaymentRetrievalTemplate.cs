using Housing.Data;
using Housing.Data.Entities;
using Housing.Data.Helpers;
using Housing.Services.Queries.Bills.Dto;
using Microsoft.EntityFrameworkCore;

namespace Housing.Services.Queries.Bills
{
    public class PaymentRetrievalTemplate
    {
        private readonly HousingContext context;

        public PaymentRetrievalTemplate(HousingContext context)
        {
            this.context = context;
        }

        public async Task<PaymentDto> Get<T>(RequestDto request, CancellationToken cancellationToken)
            where T : BaseBillingItem
        {
            var current = await context.Set<T>()
                .Aggregate(request.Date, request.EndDate)
                .SingleOrDefaultAsync(cancellationToken);

            var previous = await context.Set<T>()
                .Aggregate(request.PreviousDate, request.PreviousEndDate)
                .SingleOrDefaultAsync(cancellationToken);

            return new PaymentDto
            {
                Payment = new ValueDto(
                    current.Payment,
                    current.Payment.Diff(previous.Payment),
                    current.PaymentAVG
                )
            };
        }
    }
}
