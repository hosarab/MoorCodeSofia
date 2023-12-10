using MoorCodeSofia.Application.Abstractions;
using MoorCodeSofia.Application.Models;

namespace MoorCodeSofia.Application.UserTasks.Queries
{
    public sealed record class GetAllUserTasksQuery(int Page, int PageSize) : IQuery<List<TaskClientResponse>>
    {
    }
}
