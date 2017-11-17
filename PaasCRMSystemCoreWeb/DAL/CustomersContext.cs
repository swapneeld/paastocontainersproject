using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaasCRMSystemCoreWeb.DAL
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions<CustomersContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
