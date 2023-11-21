using cain_jawbone_resources.Inputs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cain_jawbone_api.Controllers
{
    [ApiController]
    [Route("api/page")]
    public class PageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("byNumber/{pageNumber}")]
        [ProducesResponseType(typeof(PageResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int pageNumber)
        {
            try
            {
                var cmd = new PageReadCommand(pageNumber);

                var result = await _mediator.Send(cmd);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
