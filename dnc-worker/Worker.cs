using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dnc_worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient client;
        private IConfiguration _config;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var webApp = _config.GetValue<string>("WebApp");
                var result = await client.GetAsync(webApp);

                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Web application : {WebApp} is good to go! {StatusCode}", webApp, result.StatusCode);
                }
                else
                {
                    _logger.LogError("Web application : {WebApp} is down! {StatusCode}", webApp, result.StatusCode); ;
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
