using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoorCodeSofia.API.Abstractions;
using MoorCodeSofia.Application.UserTasks.Commands;
using MoorCodeSofia.Application.UserTasks.Queries;

namespace MoorCodeSofia.API.Controllers
{
    [Route("api/userTasks")]
    public class UserTasksController : ApiController
    {
        public UserTasksController(ISender sender) : base(sender)
        {
        }

        [HttpGet("getAllTasks")]
        public async Task<IActionResult> GetAllUserTasks(CancellationToken cancellationToken)
        {
            var query = new GetAllUserTasksQuery(0, 10);
            var response = await Sender.Send(query, cancellationToken);
            return response.IsSuccess ? Ok(response) : NotFound(response.Error);
        }


        [HttpPost("create/")]
        public async Task<IActionResult> CreateUserTask(CreateUserTaskCommand command,
            CancellationToken cancellationToken)
        {
            var createCommand = new CreateUserTaskCommand(

                command.User,
                command.Description,
                command.StartDate,
                command.EndDate,
                command.Subject);

            var response = await Sender.Send(createCommand, cancellationToken);
            return Ok(response);

        }
    }
}
