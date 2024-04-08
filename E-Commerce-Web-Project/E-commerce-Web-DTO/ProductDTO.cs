using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Web_DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public byte[]? ProductPicture { get; set; }

        public int? ProductPrice { get; set; }

    }
}
