using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ToxiCode.BuyIt.Api.Kafka;

public class KafkaConsumerHostedService<TKey, TValue, THandler> : BackgroundService
    where THandler : IConsumeHandler<TKey, TValue> where TKey : class where TValue : class
{
    private readonly ILogger<KafkaConsumerHostedService<TKey, TValue, THandler>> _logger;
    private readonly IConsumer<RawData, RawData> _consumer;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly DeserializerProvider<TKey, TValue> _deserializerProvider;
    private readonly THandler _handler;
    private readonly string _topicName;
    private readonly string _groupId;

    public KafkaConsumerHostedService(
        ILogger<KafkaConsumerHostedService<TKey, TValue, THandler>> logger,
        IOptions<ConsumerKafkaOptions> options,
        DeserializerProvider<TKey, TValue> deserializerProvider, THandler handler)
    {
        _logger = logger;
        _consumer = new ConsumerBuilder<RawData, RawData>(GetConsumerConfigFromOptions(options.Value))
            .SetKeyDeserializer(new RawDataDeserializer())
            .SetValueDeserializer(new RawDataDeserializer())
            .Build();
        _cancellationTokenSource = new CancellationTokenSource();
        _topicName = options.Value.TopicName;
        _groupId = options.Value.GroupId;
        _deserializerProvider = deserializerProvider;
        _handler = handler;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await Task.Yield();
        
        _consumer.Subscribe(_topicName);
        _logger.LogInformation("Starting consuming from topic: {Topic} with groupId: {Group}", _topicName, _groupId);
        cancellationToken.Register(Finish);
        var token = _cancellationTokenSource.Token;
        try
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var rawData = await ConsumeAsync(token);
                    if (rawData is null)
                        return;

                    var deserialized = TryDeserialize(rawData, out var message);
                    switch (deserialized)
                    {
                        case true:
                        {
                            var handled = await TryHandleMessageAsync(message, token);
                            if (handled || true)
                            {
                                await CommitAsync(rawData, token);
                                _logger.LogInformation("Message successfully committed");
                            }
                               
                            // else
                            //     throw new Exception();
                            break;
                        }

                        case false:
                        {
                            _logger.LogInformation("Message didn't serialized, but successfully committed");
                            await CommitAsync(rawData, token);
                            break;
                        }
                            
                    }
                }
                catch
                {
                    //
                }
            }
        }
        catch
        {
            //
        }
        Finish();
    }
    
    private void Finish()
    {
        _cancellationTokenSource.Cancel();
        _consumer.Dispose();
        base.Dispose();
        _logger.LogInformation("Kafka worker with topic: {Topic} stopped", _topicName);
    }

    private async Task<ConsumeResult<RawData, RawData>?> ConsumeAsync(CancellationToken token)
    {
        ConsumeResult<RawData, RawData>? data = default;
        while (data?.Message == null)
        {
            data = _consumer.Consume(token);
            if (!data.IsPartitionEOF)
                continue;

            await Task.Delay(1000, token);
        }

        return data;
    }

    private bool TryDeserialize(ConsumeResult<RawData, RawData> consumedMessage, out Message<TKey, TValue> message)
    {
        var successKey = true;
        TKey? desKey = default;
        try
        {
            desKey = _deserializerProvider.KeyDeserializer.Deserialize(consumedMessage.Message.Key.Data,
                consumedMessage.Message.Key.Context);
        }
        catch
        {
            successKey = false;
        }

        var successValue = true;
        TValue? desValue = default;
        try
        {
            desValue = _deserializerProvider.ValueDeserializer.Deserialize(consumedMessage.Message.Value.Data,
                consumedMessage.Message.Value.Context);
        }
        catch
        {
            successValue = false;
        }

        var data = consumedMessage.Message;

        message = successKey && successValue
            ? new Message<TKey, TValue>
            {
                TimeStamp = data.Timestamp.UtcDateTime,
                Headers = data.Headers,
                Key = desKey!,
                Value = desValue!,
                Partition = consumedMessage.Partition.Value,
                Offset = consumedMessage.Offset.Value,
                Topic = consumedMessage.Topic,
                GroupId = _groupId
            }
            : new();


        return successKey && successValue;
    }

    private async Task<bool> TryHandleMessageAsync(Message<TKey, TValue> message, CancellationToken cancellationToken)
    {
        try
        {
            await _handler.HandleAsync(message, cancellationToken);
            return true;
        }
        catch (Exception exception) when (exception is not OperationCanceledException)
        {
            return false;
        }
    }

    private Task CommitAsync(ConsumeResult<RawData, RawData> consumeResult, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        try
        {
            _consumer.SendOffsets(CommitType.ConfluentAuto, consumeResult);
        }
        catch
        {
            //
        }


        return Task.CompletedTask;
    }


    private ConsumerConfig GetConsumerConfigFromOptions(ConsumerKafkaOptions options)
        => new()
        {
            GroupId = options.GroupId,
            BootstrapServers = options.BootstrapServers,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
}