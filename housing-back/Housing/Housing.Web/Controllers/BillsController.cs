using Housing.Services.Queries;
using Housing.Services.Queries.Dto;
using Housing.Services.Queries.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Web.Controllers
{
    public class BillsController : BaseController
    {
        public BillsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("water/{year}/{month}")]
        public Task<WaterBillDto> GetWaterBill([FromRoute] string year, [FromRoute] string month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetWaterBillQuery(year, month, type));
        }

        [HttpGet("rent/{year}/{month}")]
        public Task<PaymentDto> GetRent([FromRoute] string year, [FromRoute] string month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetRentQuery(year, month, type));
        }

        [HttpGet("heating/{year}/{month}")]
        public Task<PaymentDto> GetHeating([FromRoute] string year, [FromRoute] string month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetHeatingBillQuery(year, month, type));
        }

        [HttpGet("repairs/{year}/{month}")]
        public Task<PaymentDto> GetRepairs([FromRoute] string year, [FromRoute] string month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetRepairsBillQuery(year, month, type));
        }

        [HttpGet("electricity/{year}/{month}")]
        public Task<ElectricityBillDto> GetElectricity([FromRoute] string year, [FromRoute] string month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetElectricityBillQuery(year, month, type));
        }

        [HttpGet("additional/{year}/{month}")]
        public Task<AdditionalsBillDto> GetAdditonal([FromRoute] string year, [FromRoute] string month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetAdditionalBillsQuery(year, month, type));
        }
    }
}
