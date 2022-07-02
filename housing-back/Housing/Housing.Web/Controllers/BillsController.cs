using Housing.Services.Queries.Bills;
using Housing.Services.Queries.Bills.Dto;
using Housing.Services.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Web.Controllers
{
    public class BillsController : BaseController
    {
        public BillsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("water/{year:int}/{month:int}")]
        public Task<WaterBillDto> GetWaterBill([FromRoute] int year, [FromRoute] int month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetWaterBillQuery(year, month, type));
        }

        [HttpGet("rent/{year:int}/{month:int}")]
        public Task<PaymentDto> GetRent([FromRoute] int year, [FromRoute] int month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetRentQuery(year, month, type));
        }

        [HttpGet("heating/{year:int}/{month:int}")]
        public Task<PaymentDto> GetHeating([FromRoute] int year, [FromRoute] int month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetHeatingBillQuery(year, month, type));
        }

        [HttpGet("repairs/{year:int}/{month:int}")]
        public Task<PaymentDto> GetRepairs([FromRoute] int year, [FromRoute] int month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetRepairsBillQuery(year, month, type));
        }

        [HttpGet("electricity/{year:int}/{month:int}")]
        public Task<ElectricityBillDto> GetElectricity([FromRoute] int year, [FromRoute] int month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetElectricityBillQuery(year, month, type));
        }

        [HttpGet("additional/{year:int}/{month:int}")]
        public Task<AdditionalsBillDto> GetAdditonal([FromRoute] int year, [FromRoute] int month, [FromQuery] ReportType? type)
        {
            return _mediator.Send(new GetAdditionalBillsQuery(year, month, type));
        }
    }
}
