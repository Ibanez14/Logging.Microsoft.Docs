using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LogginByDocs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            var programLogger = host.Services.GetRequiredService<ILogger<Program>>();
            programLogger.LogInformation("Logger from Main");
            programLogger.LogWarning("Warning from Main");
            programLogger.LogCritical("Critical frmo Main");
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) // Create Default Builder by Defaul add Console and Debug
                .ConfigureLogging(logbuilder =>
                {
                    logbuilder.ClearProviders(); // if you are not happy with default logging configuration, clean providers and add new
                    logbuilder.AddConsole();
                })
                .UseStartup<Startup>();
    }
}
