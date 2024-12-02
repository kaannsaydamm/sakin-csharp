using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sakin_csharp.Services;

namespace sakin_csharp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var eventLogService = services.GetRequiredService<EventLogService>();

                // Arka planda event log toplama
                _ = Task.Run(async () => 
                {
                    try 
                    {
                        await eventLogService.StartEventLogCollectionAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Event log toplama hatası: {ex.Message}");
                    }
                });
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}