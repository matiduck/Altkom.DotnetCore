using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.HostedService
{
    public class HelloWorldHostedService : IHostedService
    {

        private readonly ILogger<HelloWorldHostedService> logger;
        private Timer timer;

        public HelloWorldHostedService(ILogger<HelloWorldHostedService> logger)
        {
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(HelloWorld, null, 0, 1000);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void HelloWorld(object state)
        {
            logger.LogInformation("Hello world !");
        }
    }
}
