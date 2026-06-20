using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        #region Relationships
        //One-to-many Order-orderItems Relationship
        public Order Order { get; set; }
        public int OrderId { get; set; }
        //One-to-Many Product-OrderItem Relationship
        public Product Product { get; set; }
        public int ProductId { get; set; }
        #endregion
    }
}
