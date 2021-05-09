using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Robot.Interface;
using Robot.Reader;
using System;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.AddTransient<IFileReader, FileReader>();
                   services.AddTransient<IRobot, PipettingRobot>();
                   services.AddTransient<IRobotRunner, RobotRunner>();
               })
               .Build();

                var robotRunner = host.Services.GetService<IRobotRunner>();
                robotRunner.Excute();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
