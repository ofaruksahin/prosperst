namespace Prosperst.Api.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BaseResponse<CreateCustomerCommandResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            return Response(response);
        }

        [HttpPost("verify")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BaseResponse<NoContent>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Verify(VerifyCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            return Response(response);
        }
    }
}