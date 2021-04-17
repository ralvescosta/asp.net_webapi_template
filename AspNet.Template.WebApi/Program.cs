using System;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AspNet.Template.WebApi.Utils;

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
                    var configurations = ctx.Configuration.GetSection("AppConfiguration").Get<Configurations>();
                    
                    logging.AddElmahIo(options => 
                    {
                        options.ApiKey = configurations.Logging.ElmahIoApiKey;
                        options.LogId = new Guid(configurations.Logging.ElmahIoLogId);
                    });
                    logging.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
