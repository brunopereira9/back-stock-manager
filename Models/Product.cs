namespace stock_manager.Models
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
            StockConferences = new List<StockConference>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<StockConference> StockConferences { get; set; }
        
    }
}