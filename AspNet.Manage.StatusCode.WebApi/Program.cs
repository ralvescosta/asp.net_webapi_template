using System;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNet.Manage.StatusCode.WebApi
{
  public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((ctx, logging) => 
                {
                    logging.AddElmahIo(options => 
                    {
                        options.ApiKey = "eb4044a8b7954580aabb8bf09cd5b0c0";
                        options.LogId = new Guid("6aba9191-d1d6-48d5-a3b1-4314c642a3dd");
                    });
                    logging.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
