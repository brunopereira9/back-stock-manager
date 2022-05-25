using Microsoft.EntityFrameworkCore;
using stock_manager.Persistence.Entities;

namespace stock_manager.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<StockConference> StockConferences { get; set; } = null!;
        
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