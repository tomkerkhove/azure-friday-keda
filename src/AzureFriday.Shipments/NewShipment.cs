using System;
using System.Threading.Tasks;
using AzureFriday.Core.Contracts;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFriday.Shipments
{
    public static class NewShipment
    {
        private static readonly Random _random = new Random();

        [FunctionName("new-shipment")]
        public static async Task Run([ServiceBusTrigger("shipments", Connection = "SERVICEBUS_NAMESPACE_CONNECTIONSTRING")] Order order, ILogger logger)
        {
            logger.LogInformation("Sending shipment for order {OrderId} with {OrderAmount} units of {OrderArticle} bought by {CustomerFirstName} {CustomerLastName}", order.Id, order.Amount, order.ArticleNumber, order.Customer.FirstName, order.Customer.LastName);

            await Task.Delay(TimeSpan.FromSeconds(_random.Next(1, 5)));
        }
    }
}
