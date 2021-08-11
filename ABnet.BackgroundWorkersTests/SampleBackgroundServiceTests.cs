using System.Threading;
using System.Threading.Tasks;
using ABnet.BackgroundWorkers;
using ABnet.BackgroundWorkers.Options;
using ABnet.BackgroundWorkers.Services;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace ABnet.BackgroundWorkersTests
{
    public class SampleBackgroundServiceTests
    {
        [Fact]
        public async Task ExecuteAsync_CallsIncrement()
        {
            var sampleServiceMock = new Mock<ISampleService>();
            sampleServiceMock.Setup(service => service.Increment());
            var options = Options.Create(new SampleBackgroundServiceOptions
            {
                Delay = 100
            });
            var backgroundService = new SampleBackgroundService(
                sampleServiceMock.Object, options);
            var expectedInvocations = 10;

            _ = backgroundService.StartAsync(new CancellationToken());
            await Task.Delay(options.Value.Delay * expectedInvocations);
            await backgroundService.StopAsync(new CancellationToken());

            Assert.Equal(expectedInvocations, sampleServiceMock.Invocations.Count);
        }
    }
}
