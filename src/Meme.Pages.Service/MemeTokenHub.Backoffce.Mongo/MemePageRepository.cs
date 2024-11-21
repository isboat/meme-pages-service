using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using MemeTokenHub.Backoffce.Models;
using MemeTokenHub.Backoffce.Mongo.Interfaces;
using MongoDB.Driver;

namespace MemeTokenHub.Backoffce.Mongo
{
    public class MemePageRepository : IRepository<MemePageModel>
    {
        private readonly IMongoCollection<MemePageModel> _collection;
        private readonly MongoClient _client;

        public MemePageRepository(IOptions<MongoSettings> settings)
        {
            _client = new MongoClient(
            settings.Value.ConnectionString);

            var mongoDatabase = _client.GetDatabase(Constants.DatabaseName);

            _collection = mongoDatabase.GetCollection<MemePageModel>(Constants.MemePagesCollection);
        }

        public Task<IEnumerable<MemePageModel>> GetByFilter(Func<MemePageModel, bool> filter)
        {
            return Task.FromResult(_collection.AsQueryable().Where(filter));
        }
    }
}