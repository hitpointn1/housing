using Housing.Services.Queries.Graph;
using Housing.Services.Queries.Graph.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Web.Controllers
{
    public class GraphController : BaseController
    {
        public GraphController(ISender mediator) : base(mediator)
        {
        }

        [HttpGet("consumptions/{year:int}")]
        public Task<ConsumptionsGraphDto> GetConsumptionsGraph([FromRoute] int year)
        {
            return _mediator.Send(new GetConsumptionsGraphQuery(year));
        }

        [HttpGet("payments/{year:int}")]
        public Task<PaymentsGraphDto> GetPaymentsGraph([FromRoute] int year)
        {
            return _mediator.Send(new GetPaymentsGraphQuery(year));
        }
    }
}
