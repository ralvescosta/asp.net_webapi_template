using System;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace AspNet.Template.WebApi
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
                    var loggingConfigs = ctx.Configuration.GetSection("AppConfiguration:Logging").Get<LogsConfig>();
                    
                    logging.AddElmahIo(options => 
                    {
                        options.ApiKey = loggingConfigs.ElmahIoApiKey;
                        options.LogId = new Guid(loggingConfigs.ElmahIoLogId);
                    });
                    logging.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
