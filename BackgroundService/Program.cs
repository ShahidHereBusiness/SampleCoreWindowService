//using SampleWorkerService;

//var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();

//var host = builder.Build();
//host.Run();
using SampleWorkerService;
using static Microsoft.Extensions.Hosting.IHostApplicationLifetime;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseWindowsService()  // Use Windows Service
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<WorkerSysTimer>(); // Register your hosted service
            });
}