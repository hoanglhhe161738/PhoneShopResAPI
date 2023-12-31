﻿using System;
using System.Collections.Generic;

namespace PhoneShopResAPI.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? PhoneId { get; set; }
        public int? Quantity { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Phone? Phone { get; set; }
    }
}
