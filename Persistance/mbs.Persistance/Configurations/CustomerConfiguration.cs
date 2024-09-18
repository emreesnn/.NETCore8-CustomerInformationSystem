using mbs.Domain.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Persistance.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255);
            Faker faker = new();
            builder.HasData(
                new Customer { Id = 1, Name = faker.Name.FullName() },
                new Customer { Id = 2, Name = faker.Name.FullName() },
                new Customer { Id = 3, Name = faker.Name.FullName() },
                new Customer { Id = 4, Name = faker.Name.FullName() },
                new Customer { Id = 5, Name = faker.Name.FullName() }
                );
        }
    }
}
