using BasketServices.Model;
using StackExchange.Redis;
using System.Text.Json;

namespace BasketServices.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository( IDatabase database)
        {
            _database = database;
        }

        public async Task<BasketOrder> GetBasketAsync(string Id)
        {
            var data = await _database.StringGetAsync(Id);
            return JsonSerializer.Deserialize<BasketOrder>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
        }

        public async Task<bool> DeleteBasket(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<BasketOrder> UpdateBasket(BasketOrder basket)
        {
            await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket));
            return await GetBasketAsync(basket.Id);
        }

    }

}
