using Event.Producer.API.Event;
using Event.Producer.API.Interface;
using MassTransit;

namespace Event.Producer.API.Service
{
    public class OrderService : IOrderService
    {
        readonly IBus _bus;
        public OrderService(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishOrder()
        {
           await _bus.Publish(new Order
           {
            OrderId = Guid.NewGuid()
           });
        }
    }
}