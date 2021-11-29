using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TutorialsXamarin.Common.Enums;

namespace TutorialsXamarin.WebAPi
{
    public class Program
    {
        public static ConnectionType ConnectionType=ConnectionType.Mock;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
