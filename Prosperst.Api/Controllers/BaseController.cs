namespace Prosperst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [NonAction]
        public IActionResult Response(BaseResponse response)
            => new OkObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
    }
}