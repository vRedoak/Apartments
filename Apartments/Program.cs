using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace Apartments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start");
            string ver = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
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
