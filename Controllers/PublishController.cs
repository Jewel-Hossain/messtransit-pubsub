//In the name of Allah

using MassTransit.My.Publisher;
using Messtransit.My.Contracts;
using Messtransit.My.Utils;
using Microsoft.AspNetCore.Mvc;

namespace messtransit_pubsub.Controllers;

[ApiController]
[Route("[controller]")]
public class PublishController : ControllerBase
{
    private readonly MyPublisher _publisher;

    public PublishController(MyPublisher publisher)
    {
        _publisher = publisher;
    }

    [HttpPost("PublishMyMessage")]
    public Task<IActionResult> PublishMyMessage([FromBody] MyMessageContract message)
    {
        _publisher.MessagePublisher(QueueNames.REPORT_SERVICE_QUEUE,message);

        return Task.FromResult<IActionResult>(Ok(message));
    }//func


    [HttpPost("PublishCity")]
    public Task<IActionResult> PublishCity([FromBody] CityContract message)
    {
         _publisher.MessagePublisher(QueueNames.REPORT_SERVICE_QUEUE,message);

        return Task.FromResult<IActionResult>(Ok(message));
    }//func

}//class

