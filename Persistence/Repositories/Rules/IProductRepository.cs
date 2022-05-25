using stock_manager.Persistence.Entities;

namespace stock_manager.Persistence.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product GetByName(string name);
        void Insert(Product product);
        void Update(Product product);
        void Remove(Product product);
        bool ProductExists(int id);
        bool GetEntityIsFound();
    }
}