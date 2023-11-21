using cain_jawbone_resources.Inputs;
using cain_jawbone_resources.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<PageReadResult>> Get([FromRoute] int pageNumber)
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
