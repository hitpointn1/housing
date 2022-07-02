using Housing.Services.Enums;
using Housing.Services.Queries.Bills;
using Housing.Services.Queries.Summary.Dto;
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
