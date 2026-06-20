using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal  TotalAmount { get; set; }
        public List<OrderItemDto> Items { get; set; }

    }
}
