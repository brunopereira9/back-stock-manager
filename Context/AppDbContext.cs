using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stock_manager.Models;

namespace stock_manager.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Product> Products { get; set; }
        public DbSet<StockConference> StockConferences { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            options.UseSqlServer(config.GetConnectionString("DatabaseLocal"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(buildAction => {
                buildAction
                .HasMany(product => product.StockConferences)
                .WithOne()
                .HasForeignKey(stockConference => stockConference.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }


    }
}