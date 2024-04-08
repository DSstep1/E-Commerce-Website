using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comemerce_Web_DAL
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public byte[]? ProductPicture { get; set; }

        public int? ProductPrice { get; set; }
    }
}

