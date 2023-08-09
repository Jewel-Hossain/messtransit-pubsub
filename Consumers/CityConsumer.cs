using MassTransit;
using Messtransit.My.Contracts;

namespace MassTransit.My.Consumers;
public class CityConsumer : IConsumer<CityContract>
{
    public async Task Consume(ConsumeContext<CityContract> context)
    {
        var data = context.Message;
        //Validate the Ticket Data
        //Store to Database
        //Notify the user via Email / SMS
        Console.WriteLine($"Recived message {data.Name}, {data.Id}");
    }//func
}//class