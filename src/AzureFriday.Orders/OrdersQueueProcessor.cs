using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AzureFriday.Core.Contracts;
using AzureFriday.Orders.Repositories;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureFriday.Orders
{
    public class OrdersQueueProcessor : QueueWorker<Order>
    {
        private readonly IShipmentRepository _shipmentRepository;

        public OrdersQueueProcessor(IShipmentRepository shipmentRepository, ServiceBusConnectionStringBuilder serviceBusConnectionStringBuilder, IConfiguration configuration, ILogger<OrdersQueueProcessor> logger)
            : base(serviceBusConnectionStringBuilder, configuration, logger)
        {
            _shipmentRepository = shipmentRepository;
        }

        protected override async Task ProcessMessage(Order order, string messageId, Message.SystemPropertiesCollection systemProperties, IDictionary<string, object> userProperties, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Processing order {OrderId} for {OrderAmount} units of {OrderArticle} bought by {CustomerFirstName} {CustomerLastName}", order.Id, order.Amount, order.ArticleNumber, order.Customer.FirstName, order.Customer.LastName);

            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);

            await _shipmentRepository.QueueNewRequestAsync(order);

            Logger.LogInformation("Order {OrderId} processed", order.Id);
        }
    }
}
