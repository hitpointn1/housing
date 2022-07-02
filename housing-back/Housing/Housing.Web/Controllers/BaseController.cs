using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected readonly ISender _mediator;

        protected BaseController(ISender mediator)
        {
            _mediator = mediator;
        }
    }
}
