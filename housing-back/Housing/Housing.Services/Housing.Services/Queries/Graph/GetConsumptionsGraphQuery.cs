using Housing.Data;
using Housing.Data.Entities;
using Housing.Data.Helpers;
using Housing.Services.Queries.Graph.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Services.Queries.Graph
{
    public class GetConsumptionsGraphQuery : GraphRequestDto, IRequest<ConsumptionsGraphDto>
    {
        public GetConsumptionsGraphQuery(int year) : base(year)
        {
        }

        private class GetConsumptionsGraphHandler : IRequestHandler<GetConsumptionsGraphQuery, ConsumptionsGraphDto>
        {
            private readonly HousingContext context;

            public GetConsumptionsGraphHandler(HousingContext context)
            {
                this.context = context;
            }

            public async Task<ConsumptionsGraphDto> Handle(GetConsumptionsGraphQuery request, CancellationToken cancellationToken)
            {
                var vertices = await context.Set<Billing>()
                    .WhereInRange(request.PreviousMonthToStart, request.End)
                    .Select(b => new ConsumptionVerticeDto
                    {
                        Date = b.Date,
                        Electricity = b.ElectricityBill.ConsumptionReadings,
                        Cold = b.WaterBill.ColdReadings,
                        Hot = b.WaterBill.HotReadings
                    })
                    .OrderBy(b => b.Date)
                    .ToDictionaryAsync(k => k.Date, v => v, cancellationToken: cancellationToken);

                return GetAnnualGraph(request.Start, vertices);
            }

            private static ConsumptionsGraphDto GetAnnualGraph(DateOnly start, Dictionary<DateOnly, ConsumptionVerticeDto> vertices)
            {
                var result = new ConsumptionsGraphDto();

                start.ForEachMonth((date, i) =>
                {
                    var previousMonth = date.AddMonths(-1);
                    if (vertices.TryGetValue(date, out ConsumptionVerticeDto dto) && vertices.TryGetValue(previousMonth, out ConsumptionVerticeDto prev))
                    {
                        result.Cold[i] = dto.Cold - prev.Cold;
                        result.Hot[i] = dto.Hot - prev.Hot;
                        result.Electricity[i] = dto.Electricity - prev.Electricity;
                        return;
                    }

                    result.Cold[i] = null;
                    result.Hot[i] = null;
                    result.Electricity[i] = null;
                });

                return result;
            }
        }
    }
}
