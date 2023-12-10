using MoorCodeSofia.Application.Abstractions;
using MoorCodeSofia.Domain;

namespace MoorCodeSofia.Application.UserTasks.Commands;

    public sealed record class UpdateUserTaskCommand
       (
        Guid id,
        string User,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string Subject) : ICommand<UserTask>;
            
 
