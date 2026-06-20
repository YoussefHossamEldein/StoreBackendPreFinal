using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        #region Relationships
        // customer-order one to many Relationship 
        public Customer Customer { get; set; } 
        public int CustomerId { get; set; }
        //Order - OrderItems one to many Relationship
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        #endregion
    }
}
