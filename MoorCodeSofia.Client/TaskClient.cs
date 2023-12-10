using Microsoft.Extensions.Logging;

namespace MoorCodeSofia.Client
{
    public class TaskClient : ITaskClient
    {
        private readonly ILogger<TaskClient> _logger;
        private readonly HttpClient _client;


        public TaskClient(ILogger<TaskClient> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }


    }

    public interface ITaskClient
    {


    }
}
