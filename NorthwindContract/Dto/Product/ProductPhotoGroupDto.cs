﻿using Microsoft.AspNetCore.Http;
using NorthwindContracts.Dto.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindContracts.Dto.Product
{
    public class ProductPhotoGroupDto
    {
        public ProductForCreateDto ProductForCreateDto { get; set; }

        [Display(Name="Photo 1")]
        public IFormFile Photo1 { get; set; }

        [Display(Name = "Photo 2")]
        public IFormFile Photo2 { get; set; }

        [Display(Name = "Photo 3")]
        public IFormFile Photo3 { get; set; }

        public List<IFormFile> AllPhoto { get; set; }
    }
}
