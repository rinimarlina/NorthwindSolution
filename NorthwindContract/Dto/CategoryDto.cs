using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace NorthwindContracts.Dto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Description cannot be longer than 50 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select image")]
        public IFormFile FilePhoto { get; set; }
    }
}
