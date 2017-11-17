using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaasCRMSystemCoreWeb.DAL
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(model => model.CustomerId);
            builder.Property(model => model.CustomerId).UseSqlServerIdentityColumn();

            builder.ToTable("Customers");
        }
    }
}
