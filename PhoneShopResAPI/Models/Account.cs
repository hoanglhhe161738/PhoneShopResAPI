using System;
using System.Collections.Generic;

namespace PhoneShopResAPI.Models
{
    public partial class Account
    {
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? full_name { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
