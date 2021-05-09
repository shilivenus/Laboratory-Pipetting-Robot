using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Robot.Interface;
using Robot.Reader;
using System;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.AddTransient<IFileReader, FileReader>();
                   services.AddTransient<IRobot, PipettingRobot>();
                   services.AddTransient<IRobotRunner, RobotRunner>();
               })
               .Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            var robotRunner = host.Services.GetService<IRobotRunner>();

            try
            {
                robotRunner.Excute();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                Console.WriteLine(e.Message);
            }
        }
    }
}
