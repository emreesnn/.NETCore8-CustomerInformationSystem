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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(255);
            Faker faker = new();
            builder.HasData(
                new Order { Id = 1, Title = faker.Commerce.ProductName(), Desc = faker.Commerce.ProductDescription(), CustomerId = 1 },
                new Order { Id = 2, Title = faker.Commerce.ProductName(), Desc = faker.Commerce.ProductDescription(), CustomerId = 2 },
                new Order { Id = 3, Title = faker.Commerce.ProductName(), Desc = faker.Commerce.ProductDescription(), CustomerId = 3 },
                new Order { Id = 4, Title = faker.Commerce.ProductName(), Desc = faker.Commerce.ProductDescription(), CustomerId = 3 },
                new Order { Id = 5, Title = faker.Commerce.ProductName(), Desc = faker.Commerce.ProductDescription(), CustomerId = 3 },
                new Order { Id = 6, Title = faker.Commerce.ProductName(), Desc = faker.Commerce.ProductDescription(), CustomerId = 4 },
                new Order { Id = 7, Title = faker.Commerce.ProductName(), Desc = faker.Commerce.ProductDescription(), CustomerId = 4 },
                new Order { Id = 8, Title = faker.Commerce.ProductName(), Desc = faker.Commerce.ProductDescription(), CustomerId = 4 },
                new Order { Id = 9, Title = faker.Commerce.ProductName(), Desc = faker.Commerce.ProductDescription(), CustomerId = 4 }
                );
        }
    }
}
