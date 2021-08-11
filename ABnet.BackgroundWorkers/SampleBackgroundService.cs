using System.Threading;
using System.Threading.Tasks;
using ABnet.BackgroundWorkers.Options;
using ABnet.BackgroundWorkers.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace ABnet.BackgroundWorkers
{
    public class SampleBackgroundService : BackgroundService
    {
        private readonly ISampleService sampleService;

        private readonly SampleBackgroundServiceOptions options;

        private readonly ILogger logger;

        public SampleBackgroundService(
            ISampleService sampleService,
            IOptions<SampleBackgroundServiceOptions> options,
            ILogger<SampleBackgroundService>? logger = null)
        {
            this.sampleService = sampleService;

            this.options = options.Value;

            this.logger = logger ?? new NullLogger<SampleBackgroundService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.logger.LogInformation("Starting {service}", nameof(SampleBackgroundService));

            await DoWork(stoppingToken);

            this.logger.LogInformation("Stopping {service}", nameof(SampleBackgroundService));
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                this.sampleService.Increment();

                await Task.Delay(this.options.Delay, stoppingToken);
            }
        }
    }
}
