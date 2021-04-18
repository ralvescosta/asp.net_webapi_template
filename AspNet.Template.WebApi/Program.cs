using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AspNet.Template.WebApi
{
  public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) 
        {
            return Host.CreateDefaultBuilder(args)
                // .ConfigureLogging((ctx, logging) => 
                // {
                //     var configurations = ctx.Configuration.GetSection("AppConfiguration").Get<Configurations>();
                    
                //     logging.AddElmahIo(options => 
                //     {
                //         options.ApiKey = configurations.Logging.ElmahIoApiKey;
                //         options.LogId = new Guid(configurations.Logging.ElmahIoLogId);
                //     });
                //     logging.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
                // })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSentry("https://6b81442b912a4ec38d8a410d0b46dc37@o256607.ingest.sentry.io/5725010");
                });
        }
    }
}
