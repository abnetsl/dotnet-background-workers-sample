using ABnet.BackgroundWorkers.Options;
using ABnet.BackgroundWorkers.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ABnet.BackgroundWorkers
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder().Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Starting to run host");

            host.Run();

            logger.LogInformation("Host stopped running");
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host
                .CreateDefaultBuilder()
                .ConfigureServices((host, services) =>
                {
                    services
                        .AddHostedService<SampleHostedService>()
                        .AddHostedService<SampleBackgroundService>();

                    services.Configure<SampleBackgroundServiceOptions>(
                        host.Configuration.GetSection("SampleBackgroundService"));

                    services.AddSingleton<ISampleService, SampleService>();
                });
        }
    }
}
