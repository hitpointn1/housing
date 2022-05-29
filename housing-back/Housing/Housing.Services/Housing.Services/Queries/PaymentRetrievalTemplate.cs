using Housing.Services.Queries.Dto;

namespace Housing.Services.Queries
{
    public class PaymentRetrievalTemplate
    {
        public Task<PaymentDto> Get(RequestDto request)
        {
            return Task.FromResult(new PaymentDto
            {
                Payment = new(13000)
            });
        }
    }
}
