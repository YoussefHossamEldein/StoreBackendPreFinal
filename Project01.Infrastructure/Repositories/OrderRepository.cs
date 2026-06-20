using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly StoreDbContext _dbContext;
        public OrderRepository(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithCustomerAndOrderItemsAsync(CancellationToken ct = default)
        {
            var orders = await _dbContext.Orders.Include(o => o.Customer).Include(o => o.OrderItems)
                                                .ThenInclude(oi => oi.Product).ToListAsync(ct);
            if (orders == null)
                return [];
            return orders;
        }

        public async Task<Order?> GetOrderByIdWithCustomerAndOrderItems(int id, CancellationToken ct = default)
        {
            return await _dbContext.Orders.Include(o => o.Customer).Include(o => o.OrderItems)
                                                .ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o=>o.Id == id);
       
        }

        public async Task<bool> UpdateOrderStatusAsync(int id, string status, CancellationToken ct = default)
        {
            var order = await _dbContext.Orders.FindAsync(id,ct);
            if (order == null)
                return false;
            order.Status = status;
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }
    }
}
