using System.Threading.Tasks;
using AzureFriday.Core.Contracts;

namespace AzureFriday.Orders.Repositories
{
    public interface IShipmentRepository
    {
        Task QueueNewRequestAsync(Order order);
    }
}
