namespace Event.Producer.API.Interface
{
    public interface IOrderService
    {
        Task PublishOrder();
    }
}