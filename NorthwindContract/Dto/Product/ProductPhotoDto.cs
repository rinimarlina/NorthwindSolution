using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindContracts.Dto.Product
{
    public class ProductPhotoDto
    {
        public int PhotoId { get; set; }
        public string PhotoFilename { get; set; }
        public short? PhotoFileSize { get; set; }
        public string PhotoFileType { get; set; }
        public int? PhotoProductId { get; set; }
        public int? PhotoPrimary { get; set; }

        public virtual ProductDto PhotoProducts { get; set; }
        public virtual ICollection<ProductPhotoGroupDto> productPhotoGroupDtos { get; set; }   
    }
}
