using System.Text;
using System.Threading.Tasks;
using AzureFriday.Core.Contracts;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AzureFriday.Orders.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly QueueClient _queueClient;

        public ShipmentRepository(ServiceBusConnectionStringBuilder connectionStringBuilder, IConfiguration configuration)
        {
            var shipmentsQueue = configuration.GetValue<string>("SERVICEBUS_QUEUE_SHIPMENTS");
            
            _queueClient = new QueueClient(connectionStringBuilder.GetNamespaceConnectionString(), shipmentsQueue, ReceiveMode.PeekLock);
        }

        public async Task QueueNewRequestAsync(Order order)
        {
            var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(order)));

            await _queueClient.SendAsync(message);
        }
    }
}
