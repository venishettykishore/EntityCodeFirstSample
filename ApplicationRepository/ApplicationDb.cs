using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRepository
{
  public   class ApplicationDb :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Consumers> Consumers { get; set; }
    }
}
