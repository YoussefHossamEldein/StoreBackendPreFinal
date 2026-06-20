using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public int Stock { get; set; }
        public bool IsAvailable { get; set; }
        #region Relationships
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        #endregion

    }
}
