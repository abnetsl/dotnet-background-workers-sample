using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ABnet.BackgroundWorkers
{
    public class SampleHostedService : IHostedService
    {
        private readonly ILogger logger;

        public SampleHostedService(
            ILogger<SampleHostedService>? logger = null)
        {
            this.logger = logger ?? new NullLogger<SampleHostedService>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Starting {service}", nameof(SampleHostedService));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Stopping {service}", nameof(SampleHostedService));

            return Task.CompletedTask;
        }
    }
}
