using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindContracts.Dto
{
    public class ProductDto
    {
        public long? productId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(15,2")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please select image")]
        public IFormFile FilePhoto { get; set; }
        public int CategoryId { get; set; }
    }
}
