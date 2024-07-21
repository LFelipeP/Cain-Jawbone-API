using Cain.Jawbone.Resource.Inputs;
using Cain.Jawbone.Resource.Models;
using cain_jawbone_resources.Inputs;
using cain_jawbone_resources.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cain_jawbone_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/page")]
    public class PageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("resume")]
        public async Task<ActionResult<GetResumedPagesResult>> Get()
        {
            try
            {
                var cmd = new GetResumedPagesCommand();

                var result = await _mediator.Send(cmd);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("byNumber/{pageNumber}")]
        public async Task<ActionResult<PageResult>> Get([FromRoute] int pageNumber)
        {
            try
            {
                var cmd = new ReadPageCommand(pageNumber);

                var result = await _mediator.Send(cmd);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PageResult>> Post([FromBody] PageModel page)
        {
            try
            {
                var cmd = new CreatePageCommand(page);

                var result = await _mediator.Send(cmd);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<PageResult>> Put([FromBody] PageModel page)
        {
            try
            {
                var cmd = new UpdatePageCommand(page);

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
