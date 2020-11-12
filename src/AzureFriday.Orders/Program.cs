using AzureFriday.Orders.Extensions;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzureFriday.Orders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            return Host.CreateDefaultBuilder(args)
                        .ConfigureAppConfiguration((hostingContext, config) => config.AddConfiguration(configuration))
                        .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                        {
                            loggingBuilder.AddConsole(consoleLoggerOptions => consoleLoggerOptions.TimestampFormat = "[HH:mm:ss]");
                        })
                        .ConfigureServices(services =>
                        {
                            services.AddTransient<ServiceBusConnectionStringBuilder>(s =>
                            {
                                var namespaceConnectionString =
                                    configuration.GetValue<string>("SERVICEBUS_NAMESPACE_CONNECTIONSTRING");
                                return new ServiceBusConnectionStringBuilder(namespaceConnectionString);
                            });
                            services.AddShipmentsIntegration();
                            services.AddOrdersProcessor();
                        });
        }
    }
}
