﻿using Northwind.Domain.Models;
using NorthwindContracts.Dto.Order;
using NorthwindContracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindContracts.Dto.OrderDetail
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual OrderDto Order { get; set; }
        public virtual ProductDto Product { get; set; }
    }
}
