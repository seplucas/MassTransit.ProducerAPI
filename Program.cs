using Event.Producer.API.Interface;
using Event.Producer.API.Service;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddMassTransit(x =>
    {
        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("localhost", "/", h =>
            {
                h.Username("guest");
                h.Password("guest");
            });
        });

    });
var app = builder.Build();

app.MapPost("/order/created", async ([FromServices]IOrderService _orderService) => 
{
   await _orderService.PublishOrder();
});

app.Run();
