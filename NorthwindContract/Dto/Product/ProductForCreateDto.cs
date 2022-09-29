﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindContracts.Dto.Category
{
    public class ProductForCreateDto
    {
        [Display(Name="Product Name")]
        [Required]
        [StringLength(50,ErrorMessage ="Product name cannot be longer than 50")]
        public string ProductName { get; set; }


        [Display(Name = "Supllier")]
        [Required]
        public int? SupplierId { get; set; }


        [Display(Name = "Category")]
        [Required]
        public int? CategoryId { get; set; }


        public string QuantityPerUnit { get; set; }


        [Display(Name = "Price")]
        [Required]
        [Range(1, 9999999999.99)]
        public decimal? UnitPrice { get; set; }


        [Display(Name = "Unit in Stock")]
        public short? UnitsInStock { get; set; }
      
        public short? UnitsOnOrder { get; set; }
        
        public short? ReorderLevel { get; set; }
        
        public bool Discontinued { get; set; }

        public virtual CategoryDto Category { get; set; }
    }
}