using MemeTokenHub.Backoffce.Services.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MemeTokenHub.Backoffce.Services
{
    public class RedisCacheService : IReadonlyCacheService
    {
        private readonly IDatabase _db;
        private readonly string _sortedSetKey = "mySortedSet";

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public async Task<List<T>> GetItemsFromList<T>()
        {
            double currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var items = await _db.SortedSetRangeByScoreAsync(_sortedSetKey, 0, currentTimestamp, Exclude.Stop);
            
            var itemList = new List<T>();
            foreach (var item in items) 
            { 
                if(string.IsNullOrEmpty(item)) continue;

                var deSerialized = JsonConvert.DeserializeObject<T>(item!);
                if(deSerialized != null) itemList.Add(deSerialized); 
            }

            return itemList;
        }
    }
}