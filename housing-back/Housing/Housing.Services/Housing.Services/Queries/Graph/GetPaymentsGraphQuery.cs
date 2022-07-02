using Housing.Data;
using Housing.Data.Entities;
using Housing.Data.Helpers;
using Housing.Services.Queries.Graph.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Services.Queries.Graph
{
    public class GetPaymentsGraphQuery : GraphRequestDto, IRequest<PaymentsGraphDto>
    {
        public GetPaymentsGraphQuery(int year) : base(year)
        {
        }

        private class GetPaymentsGraphHandler : IRequestHandler<GetPaymentsGraphQuery, PaymentsGraphDto>
        {
            private readonly HousingContext context;

            public GetPaymentsGraphHandler(HousingContext context)
            {
                this.context = context;
            }

            public async Task<PaymentsGraphDto> Handle(GetPaymentsGraphQuery request, CancellationToken cancellationToken)
            {
                var vertices = await context.Set<Billing>()
                    .WhereInRange(request.Start, request.End)
                    .Select(b => new PaymentsVerticeDto
                    {
                        Date = b.Date,
                        Additionals = b.Additionals.Payment,
                        Internet = b.Additionals.Internet,
                        Electricity = b.ElectricityBill.Payment,
                        Heating = b.HeatingBill.Payment,
                        Rent = b.Rent.Payment,
                        Repairs = b.RepairsBill.Payment,
                        Water = b.WaterBill.Payment
                    })
                    .OrderBy(b => b.Date)
                    .ToDictionaryAsync(k => k.Date, v => v, cancellationToken: cancellationToken);
                
                return GetAnnualGraph(request.Start, vertices);
            }

            private static PaymentsGraphDto GetAnnualGraph(DateOnly start, Dictionary<DateOnly, PaymentsVerticeDto> vertices)
            {
                var result = new PaymentsGraphDto();

                start.ForEachMonth((date, i) =>
                {
                    if (vertices.TryGetValue(date, out PaymentsVerticeDto dto))
                    {
                        result.Additionals[i] = dto.Additionals;
                        result.Internet[i] = dto.Internet;
                        result.Electricity[i] = dto.Electricity;
                        result.Heating[i] = dto.Heating;
                        result.Rent[i] = dto.Rent;
                        result.Repairs[i] = dto.Repairs;
                        result.Water[i] = dto.Water;
                        return;
                    }

                    result.Additionals[i] = null;
                    result.Internet[i] = null;
                    result.Electricity[i] = null;
                    result.Heating[i] = null;
                    result.Rent[i] = null;
                    result.Repairs[i] = null;
                    result.Water[i] = null;
                });

                return result;
            }
        }
    }
}
