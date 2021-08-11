using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ABnet.BackgroundWorkers.Services
{
    public class SampleService : ISampleService
    {
        private readonly ILogger logger;

        public SampleService(ILogger<SampleService>? logger = null)
        {
            this.Count = 0;

            this.logger = logger ?? new NullLogger<SampleService>();
        }

        public int Count { get; private set; }

        public void Increment()
        {
            this.Count++;

            this.logger.LogInformation("Count incremented to {count}", this.Count);
        }
    }
}
