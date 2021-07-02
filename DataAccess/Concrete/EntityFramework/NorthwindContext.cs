using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context nesnesi :db tabloları ile proje classlarını bağlamak
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //projenin hangi db ile ilişkili oldugunun belirtildiği alandır.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GFCEB34;Database=Northwind;Trusted_Connection=true");

        }

        //hangi tabloya ne karşılk geliyor:
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
