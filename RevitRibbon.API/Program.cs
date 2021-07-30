using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RevitRibbon.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:5003", "https://localhost:5004");
                    webBuilder.UseIISIntegration();
                });
    }
}