//In the name of Allah

namespace MassTransit.My.Publisher;

public class MyPublisher
{
    private readonly IBus _bus;
    public MyPublisher(IBus bus)
    {
        _bus = bus;
    }
    public async void MessagePublisher<T>(string queueName, T message)
    {
        if (message is null) return;
        var queueUri = new Uri(queueName);
        var sendEndpoint = await _bus.GetSendEndpoint(queueUri);
        await sendEndpoint.Send(message);
    }//func
}//class