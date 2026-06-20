using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = default!;
        #region Relationships
        // customer-order one to many Relationship 
        public ICollection<Order> CustomerOrders { get; set; } = new List<Order>();
        #endregion
    }
}
