using System;
using System.Collections.Generic;

namespace PhoneShopResAPI.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string? Username { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Account? UsernameNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
