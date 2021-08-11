using System;
using System.Threading.Tasks;

namespace ABnet.BackgroundWorkers.Services
{
    public interface ISampleService
    {
        void Increment();

        int Count { get; }
    }
}
