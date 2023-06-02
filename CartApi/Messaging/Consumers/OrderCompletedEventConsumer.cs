using CartApi.Data;
using Common.Messaging;
using MassTransit;
using RabbitMQ.Client;

namespace CartApi.Messaging.Consumers
    {
    public class OrderCompletedEventConsumer : IConsumer<OrderCompletedEvent>
        {
        private readonly ICartRepository _repository;
        public OrderCompletedEventConsumer(ICartRepository cartRepository) 
            { 
            _repository = cartRepository;
            }

        public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
            {
            await _repository.DeleteCartAsync(context.Message.BuyerId);
            }
        }
    }
