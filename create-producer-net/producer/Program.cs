using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace VehiclePositionProducer
{
    class Program
    {
        // Requires C# language version 7.1+
        static async Task Main(string[] args)
        {
            Console.WriteLine("*** Starting VP Producer ***");

            try
            {
                var tokenSource = new CancellationTokenSource();
                var isCancelled = false;
                
                Console.CancelKeyPress += (sender, e) =>
                {
                    isCancelled = e.Cancel = true;

                    tokenSource.Cancel();
                };
                
                var producerBuilder = CreateProducerBuilder();

                using (var producer = producerBuilder.Build())
                {
                    var subscriber = new Subscriber(producer);

                    await subscriber.StartAsync(tokenSource.Token);

                    while (!isCancelled)
                    {
                        // Cancelled will be changed when Console.CancelKeyPressed is fired.
                        await Task.Delay(TimeSpan.FromMilliseconds(100));
                    }

                    await subscriber.StopAsync();
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Received signal to shut down.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Encountered error {0}", e);
                Console.WriteLine("*** Stopping VP Producer ***");
            }

            Console.WriteLine("*** Stopped VP Producer ***");
        }

        private static ProducerBuilder<string, string> CreateProducerBuilder()
        {
            var settings = new ProducerConfig
            {
                ClientId = "vp-producer",
                BootstrapServers = "kafka:9092",
            };
            var producerBuilder = new ProducerBuilder<string, string>(settings);

            return producerBuilder;
        }
    }
}
