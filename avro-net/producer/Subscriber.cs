using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Models;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using Newtonsoft.Json;
using solution.model;

namespace VehiclePositionProducer
{
    public class Subscriber
    {
        private const int QualityOfService = 1;
        private const string MqttHost = "mqtt.hsl.fi";
        private const int MqttHostPort = 8883;
        private const string ClientIdPrefix = "MQTT-Java-Example";
        private const string MqttTopic = "/hfp/v2/journey/ongoing/vp/#";
        private const string KafkaTopic = "vehicle-positions-avro";
        
        private readonly string _clientId;
        private readonly IMqttClient _client;
        private readonly IProducer<PositionKey, PositionValue> _producer;

        public Subscriber(IProducer<PositionKey, PositionValue> producer)
        {
            _producer = producer;
            _clientId = $"{ClientIdPrefix}-{Guid.NewGuid()}";
            _client = new MqttFactory().CreateMqttClient();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var clientOptions = new MqttClientOptionsBuilder()
                .WithClientId(_clientId)
                .WithCleanSession(true)
                .WithTcpServer(MqttHost, MqttHostPort)
                .WithTls()
                .Build();

            _client.UseApplicationMessageReceivedHandler(e => OnMessageReceived(e));
            _client.UseConnectedHandler(e => OnConnected(e));
            
            await _client.ConnectAsync(clientOptions, cancellationToken);
        }

        public Task StopAsync()
        {
            return _client.DisconnectAsync();
        }

        private async Task OnMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            var payload = e.ApplicationMessage.ConvertPayloadToString();
            Console.WriteLine($"Message arrived: {e.ApplicationMessage.Topic} - {payload}");

            var messageKey = new PositionKey
            {
                topic = e.ApplicationMessage.Topic
            };
            var messageValue = JsonConvert.DeserializeObject<VehiclePosition>(payload);
            var message = new Message<PositionKey, PositionValue>
            {
                Key = messageKey,
                Value = messageValue.VP
            };

            try
            {
                var result = await _producer.ProduceAsync(KafkaTopic, message);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine($"Error producing message: {exception}");
            }
        }

        private async Task OnConnected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("Connected to MQTT host");

            var topicSubscription = new TopicFilterBuilder()
                .WithTopic(MqttTopic)
                .WithExactlyOnceQoS()
                .Build();

            var result = await _client.SubscribeAsync(topicSubscription);

            Console.WriteLine($"Subscribed to {MqttTopic}");
        }
    }
}