namespace BasketServices.Model
{
    public interface IBasketRepository
    {
        public Task<BasketOrder> GetBasketAsync(string id);
        public Task<bool> DeleteBasket(string id);
        public Task<BasketOrder> UpdateBasket(BasketOrder basket);
    }
}
