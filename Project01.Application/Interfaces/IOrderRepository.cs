using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<bool> UpdateOrderStatusAsync(int id, string status, CancellationToken ct = default);
        Task<IEnumerable<Order>> GetAllOrdersWithCustomerAndOrderItemsAsync(CancellationToken ct = default);
        Task<Order?> GetOrderByIdWithCustomerAndOrderItems(int id, CancellationToken ct = default);
    } 
}
