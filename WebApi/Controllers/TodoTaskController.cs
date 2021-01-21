using AutoMapper;
using CBC.TaskManagement.WebApi.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.WebApi.Service.Query;

namespace CBC.TaskManagement.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class TodoTaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private readonly ILogger<TodoTaskController> _logger;

        public TodoTaskController(IMapper mapper, IMediator mediator, ILogger<TodoTaskController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        ///     Action to retrieve all todo tasks.
        /// </summary>
        /// <returns>Returns a list of all todo tasks or an empty list.</returns>
        /// <response code="200">Returned if the list of tasks was retrieved</response>
        /// <response code="400">Returned if the taks could not be retrieved</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTask>>> TodoTasks()
        {
            try
            {
                return await _mediator.Send(new GetTodoTaskQuery());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
