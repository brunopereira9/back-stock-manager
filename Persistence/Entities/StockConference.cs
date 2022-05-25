namespace stock_manager.Persistence.Entities
{
    public class StockConference
    {

        public StockConference(decimal quantity, decimal price)
        {
            Quantity = quantity;
            Price = price;
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
    }
}