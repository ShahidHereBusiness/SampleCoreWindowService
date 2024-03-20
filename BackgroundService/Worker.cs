using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWorkerService
{
    public class ConsumeScopedServiceHostedService : BackgroundService
    {
        private readonly ILogger<ConsumeScopedServiceHostedService> _logger;
        readonly string? logName = "WorkerApp";
        readonly string? src = "TimerWorkerMinimalApi";

        public ConsumeScopedServiceHostedService(IServiceProvider services,
            ILogger<ConsumeScopedServiceHostedService> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }

        public override async Task StartAsync(CancellationToken stoppingToken)
        {
            // Run your graceful clean-up actions
            if (!EventLog.SourceExists(src))
            {
                EventLog.CreateEventSource(src, logName);
                Console.WriteLine("Service Started.");
            }
            EventLog.WriteEntry(src, "Consume Scoped Service Hosted Service is starting.", EventLogEntryType.Information);

            await base.StartAsync(stoppingToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Run your graceful clean-up actions
            if (!EventLog.SourceExists(src))
            {
                EventLog.CreateEventSource(src, logName);
                Console.WriteLine("Service Started.");
            }
            EventLog.WriteEntry(src, "Consume Scoped Service Hosted Service running.", EventLogEntryType.Information);

            while (!stoppingToken.IsCancellationRequested)
            {                
                await DoWork(stoppingToken);
                await Task.Delay(new TimeSpan(0, 0, 5));
            }
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            // Run your graceful clean-up actions
            if (!EventLog.SourceExists(src))
            {
                EventLog.CreateEventSource(src, logName);
                Console.WriteLine("Service Started.");
            }
            EventLog.WriteEntry(src, "Consume Scoped Service Hosted Service is working.", EventLogEntryType.Information);                        
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            // Run your graceful clean-up actions
            if (!EventLog.SourceExists(src))
            {
                EventLog.CreateEventSource(src, logName);
                Console.WriteLine("Service Started.");
            }
            EventLog.WriteEntry(src, "Consume Scoped Service Hosted Service is stopping.", EventLogEntryType.Information);            

            await base.StopAsync(stoppingToken);
        }
    }
}