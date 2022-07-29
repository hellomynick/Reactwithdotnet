namespace BasketServices.Model
{
    public class BasketOrder
    {
        public string Id { get; set; } = "1";
        public List<BasketItem> Items { get; set; } = new();
        public BasketOrder()
        {

        }
        public BasketOrder(string id = "1")
        {
            Id = id;
        }
    }
}
