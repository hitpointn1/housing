using Housing.Data;
using Housing.Data.Entities;
using Housing.Data.Helpers;
using Housing.Services.Helpers;
using Housing.Services.Queries.Dto;
using Microsoft.EntityFrameworkCore;

namespace Housing.Services.Queries
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

            var paymentDiff = MathHelper.Diff(current.Payment, previous.Payment);

            return new PaymentDto
            {
                Payment = new ValueDto(current.Payment, paymentDiff, current.PaymentAVG),
            };
        }
    }
}
