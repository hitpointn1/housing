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

        [HttpGet("{year}/{month}")]
        public Task<SummaryDto> Get([FromRoute] string year, [FromRoute] string month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetSummaryQuery(year, month, type));
        }
    }
}
