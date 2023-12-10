namespace MoorCodeSofia.Domain.Contracts;

public interface IUserTaskRepository
{
    Task<List<UserTask>> GetAllTasksAsync(CancellationToken cancellationToken = default);
    Task<UserTask> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserTask> DeleteTaskAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> AddAsync(UserTask userTask, CancellationToken camCancellationToken = default);
    void Update(UserTask userTask);
}