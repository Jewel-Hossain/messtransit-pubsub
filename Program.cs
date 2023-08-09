//In the name of Allah

global using MassTransit;
using MassTransit.My.Consumers;
using MassTransit.My.Publisher;
using Messtransit.My.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CityConsumer>();
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        var connection = new Uri("amqp://admin:admin2023@18.138.164.11:5672");
        cfg.Host(connection);
        cfg.ReceiveEndpoint(QueueRoutes.RESTAURANT_SERVICE_QUEUE_ROUTE, ep =>
       {
           ep.PrefetchCount = Environment.ProcessorCount;
           ep.UseMessageRetry(r => r.Interval(2, 100));
           ep.ConfigureConsumer<CityConsumer>(provider);
       });

    }));
});
builder.Services.AddScoped<MyPublisher>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
