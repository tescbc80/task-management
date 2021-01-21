using AutoMapper;
using CBC.TaskManagement.WebApi.Domain;
using CBC.TaskManagement.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.WebApi.Service.Command;
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

        /// <summary>
        ///     Action to create a new task in the database.
        /// </summary>
        /// <param name="taskModel">Model to create a new <see cref="TodoTaskModel"/> object.</param>
        /// <returns>Returns the created instance.</returns>
        /// <response code="200">Returned if the task was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<TodoTask>> Create(TodoTaskModel taskModel)
        {
            try
            {
                return await _mediator.Send(new CreateTodoTaskCommand
                {
                    Task = _mapper.Map<TodoTask>(taskModel)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Action to update status of the task.
        /// </summary>
        /// <param name="id">The id of the task.</param>
        /// <returns>Returns the updated task</returns>
        /// <response code="200">Returned if the task was updated.</response>
        /// <response code="400">Returned if the task could not be found with the provided id</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("SetStatus/{id}/{status}")]
        public async Task<ActionResult<TodoTask>> SetStatus(Guid id, TodoTaskStatus status)
        {
            try
            {
                var task = await _mediator.Send(new GetTodoTaskByIdQuery
                {
                    Id = id
                });

                if (task == null)
                {
                    return BadRequest($"No task found with the id {id}");
                }

                task.Status = status;

                return await _mediator.Send(new SetTaskStatusCommand
                {
                    Task = _mapper.Map<TodoTask>(task)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Action to delete a task.
        /// </summary>
        /// <param name="id">The id of the task.</param>
        /// <returns>Returns the deleted task</returns>
        /// <response code="200">Returned if the task was deleted.</response>
        /// <response code="400">Returned if the task could not be found with the provided id</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var task = await _mediator.Send(new GetTodoTaskByIdQuery
                {
                    Id = id
                });

                if (task == null)
                {
                    return BadRequest($"No task found with the id {id}");
                }

                await _mediator.Send(new DeleteTodoTaskCommand
                {
                    Task = _mapper.Map<TodoTask>(task)
                });

                return this.Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
