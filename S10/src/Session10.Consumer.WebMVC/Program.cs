using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Session10.Consumer.WebMVC.Services;

namespace Session10.Consumer.WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            
            .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
            {
                AddJsonFile(configurationBuilder);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(loggingBuilder =>
            {
                SetupLogRole(loggingBuilder);
            })
            ;

        private static void SetupLogRole(ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddConsole();
            loggingBuilder.AddDebug();
            loggingBuilder.AddEventLog(new Microsoft.Extensions.Logging.EventLog.EventLogSettings() { MachineName = "" });
        }

        /// <summary>
        /// روش اضافه کردن فایل جیسون به تنظیمات مربوطه به فایل کانفیگوریشن
        /// </summary>
        /// <param name="configurationBuilder"></param>
        private static void AddJsonFile(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddJsonFile("appsettings.ConnectionString.json", optional: true, reloadOnChange: true);
        }
    }

}
