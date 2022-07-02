using Housing.Services.Queries;
using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Web.Controllers
{
    public class SummaryController : BaseController
    {
        public SummaryController(IMediator mediator)
            : base(mediator) { }

        [HttpGet("{year:int}/{month:int}")]
        public Task<SummaryDto> Get([FromRoute] int year, [FromRoute] int month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetSummaryQuery(year, month, type));
        }
    }
}
