using RealTime.Consumer.Model;

namespace RealTime.Consumer;

internal interface IConsumer
{
    void Start();
    void ConsumeMessage(Message message);
}
