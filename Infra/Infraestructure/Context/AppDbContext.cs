using Domain.Entities.Client;
using Domain.Entities.Product;
using Domain.Entities.Purchase;
using Domain.Value_Objects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Infraestructure.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }


        public DbSet<Products> Products { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<ProductStock> ProductsInStock { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Buyer>().HasKey(x => x.Id);
            builder.Entity<Buyer>().OwnsOne(x => x.Address);
            builder.Entity<Buyer>().OwnsOne(x => x.name);

            builder.Entity<Products>().HasKey(x => x.Id);
            builder.Entity<Products>().OwnsOne(p => p.ProductName);

            builder.Entity<ProductStock>().HasKey(p => p.Id);

            builder.Entity<Purchases>().HasKey(p => p.Id);

            builder.Entity<Buyer>().OwnsMany(c => c.CellPhoneNumbers);
            builder.Entity<Buyer>().OwnsMany(f=> f.Emails);

            base.OnModelCreating(builder);
        }


    }
}
