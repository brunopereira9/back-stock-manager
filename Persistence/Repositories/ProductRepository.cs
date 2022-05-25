using Microsoft.EntityFrameworkCore;
using stock_manager.Persistence.Context;
using stock_manager.Persistence.Entities;

namespace stock_manager.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<Product> GetEntity(){
            return _context.Products;
        }

        public bool GetEntityIsFound(){
            return GetEntity() != null ? true : false;
        }

        public bool ProductExists(int id){
            return (GetEntity()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public List<Product> GetAll()
        {
            return GetEntity()
                .Include(
                    product => product.StockConferences
                        .OrderByDescending(stockConferences=>stockConferences.Id)
                        .Take(1)
                )
                .Where(product => product.IsDeleted == false)
                .ToList();
        }

        public Product GetById(int id)
        {
            return GetEntity()?
                .Include(
                    product => product.StockConferences
                        .OrderByDescending(stockConferences=>stockConferences.Id)
                )
                .SingleOrDefault(product => product.Id == id)!;
        }

        public Product GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product product)
        {
            GetEntity().Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Product product)
        {
            product.SoftRemove();
            Update(product);
        }

    }
}