namespace BasketServices.Model
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
}
