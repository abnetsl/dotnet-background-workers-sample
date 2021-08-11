using ABnet.BackgroundWorkers.Services;
using Xunit;

namespace ABnet.BackgroundWorkersTests.Services
{
    public class SampleServiceTests
    {
        [Fact]
        public void Constructor_InitializesCountToZero()
        {
            var service = new SampleService();

            Assert.Equal(0, service.Count);
        }

        [Fact]
        public void Increment_IncrementsCountByOne()
        {
            var service = new SampleService();

            service.Increment();

            Assert.Equal(1, service.Count);
        }
    }
}
