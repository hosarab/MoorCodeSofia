using MoorCodeSofia.Domain;
using MoorCodeSofia.Domain.Contracts;


namespace MoorCodeSofia.Infrastructure.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        public IList<UserTask> GetAll() => DataSet.AllUserTasks;



        public async Task<List<UserTask>> GetAllTasksAsync(CancellationToken cancellationToken = default)
        {
            // return await _dbContext.Set<UserTask>().ToListAsync(cancellationToken: cancellationToken);

            return

              await Task.FromResult(
                GetAll()
                .OrderByDescending(p => p.StartDate)
                .ThenBy(p => p.User).ToList());
        }



        public async Task<UserTask> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UserTask> DeleteTaskAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> AddAsync(UserTask userTask, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
                DataSet.AllUserTasks.Add(userTask), cancellationToken).ConfigureAwait(false);

            return userTask.Id;
            //._dbContext.Set<UserTask>().AddAsync(userTask, cancellationToken);


        }

        public void Update(UserTask userTask)
        {
            throw new NotImplementedException();
        }
    }
}

