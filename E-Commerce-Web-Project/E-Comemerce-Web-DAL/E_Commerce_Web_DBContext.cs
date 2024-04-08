using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comemerce_Web_DAL
{
    public partial class E_Commerce_Web_DBContext : DbContext
    {
        public E_Commerce_Web_DBContext(DbContextOptions<E_Commerce_Web_DBContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}

