using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace sakin_csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Uygulamanın ana giriş noktası
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Uygulamanın başlangıç ayarlarını yapılandır
                    webBuilder.UseStartup<Startup>();
                });
    }
}