using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;

namespace VehiclePositionProducer
{
    public class Subscriber
    {
        private const int QualityOfService = 1;
        private const string MqttHost = "mqtt.hsl.fi";
        private const int MqttHostPort = 8883;
        private const string ClientIdPrefix = "MQTT-Java-Example";
        private const string MqttTopic = "/hfp/v2/journey/ongoing/vp/#";
        private const string KafkaTopic = "vehicle-positions";
        
        private readonly string _clientId;
        private readonly IMqttClient _client;
        private readonly IProducer<string, string> _producer;

        public Subscriber(IProducer<string, string> producer)
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

            var messageKey = e.ApplicationMessage.Topic;
            var messageValue = payload;
            var message = new Message<string, string>
            {
                Key = messageKey,
                Value = messageValue
            };

            await _producer.ProduceAsync(KafkaTopic, message);
        }

        private async Task OnConnected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("Connected to MQTT host");

            var topicSubscription = new TopicFilterBuilder()
                .WithTopic(MqttTopic)
                .WithExactlyOnceQoS()
                .Build();

            await _client.SubscribeAsync(topicSubscription);

            Console.WriteLine($"Subscribed to {MqttTopic}");
        }
    }
}