using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using solution.model;

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
                
                using (var schemaRegistryClient = CreateSchemaRegistryClient())
                {
                    var producerBuilder = CreateProducerBuilder(schemaRegistryClient);

                    using (var producer = producerBuilder.Build())
                    {
                        var subscriber = new Subscriber(producer);

                        await subscriber.StartAsync(tokenSource.Token);

                        while (!isCancelled)
                        {
                            // Cancelled will be changed when Console.CancelKeyPressed is fired.
                            await Task.Delay(TimeSpan.FromMilliseconds(100));
                        }
                    }
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

        private static ISchemaRegistryClient CreateSchemaRegistryClient()
        {
            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = "http://schema-registry:8081/",
            };

            return new CachedSchemaRegistryClient(schemaRegistryConfig);
        }

        private static ProducerBuilder<PositionKey, PositionValue> CreateProducerBuilder(ISchemaRegistryClient schemaRegistryClient)
        {
            var settings = new ProducerConfig
            {
                ClientId = "vp-producer-avro",
                BootstrapServers = "kafka:9092",
            };
            var avroSerializerConfig = new AvroSerializerConfig
            {
                AutoRegisterSchemas = true,
            };
            var producerBuilder = new ProducerBuilder<PositionKey, PositionValue>(settings)
                .SetKeySerializer(new AvroSerializer<PositionKey>(schemaRegistryClient, avroSerializerConfig))
                .SetValueSerializer(new AvroSerializer<PositionValue>(schemaRegistryClient, avroSerializerConfig));

            return producerBuilder;
        }
    }
}
