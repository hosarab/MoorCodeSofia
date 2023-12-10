using MoorCodeSofia.Domain;

namespace MoorCodeSofia.Infrastructure
{
    public static class DataSet
    {
        public static readonly List<UserTask> AllUserTasks =
            new()
            {
                new UserTask
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Parse("08/12/2023"),
                    Description = "Nazdar Description",
                    EndDate = DateTime.Parse("18/12/2023"),
                    Subject = "Nazdar Subject",
                    User = "Nazdar"
                },
                new UserTask
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Parse("08/12/2023"),
                    Description = "Murat Description",
                    EndDate = DateTime.Parse("18/12/2023"),
                    Subject = "Murat Subject",
                    User = "Murat"
                }

            };
    }
}
