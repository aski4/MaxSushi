using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enities;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
