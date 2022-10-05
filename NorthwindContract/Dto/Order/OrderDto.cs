using NorthwindContracts.Dto.OrderDetail;
using NorthwindContracts.Dto.Shipper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindContracts.Dto.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        //public virtual Customer Customer { get; set; }
        //public virtual Employee Employee { get; set; }
        public virtual ShipperDto ShipViaNavigation { get; set; }
        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}
