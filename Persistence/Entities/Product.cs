using stock_manager.Persistence.Models;

namespace stock_manager.Persistence.Entities
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            IsDeleted = false;
            StockConferences = new List<StockConference>();
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public List<StockConference> StockConferences { get; private set; }
        
        public void SetStockConference(StockConferenceModel model) {
            StockConferences.Add(new StockConference(model.Quantity, model.Price));
            UpdatedAt = DateTime.Now;
        }

        public void SetName(string name){
            Name = name;
            UpdatedAt = DateTime.Now;
        }

        public void SoftRemove(){
            IsDeleted = true;
            DeletedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}