using NorthwindContracts.Dto.Order;
using NorthwindContracts.Dto.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindContracts.Dto.Product
{
    public class ProductOrderGroupDto
    {
        public ProductDto product { get; set; }
        public OrderForCreateDto orderForCreateDto { get; set; }
        public OrderDetailForCreateDto orderDetailForCreateDto { get; set; }
    }
}
