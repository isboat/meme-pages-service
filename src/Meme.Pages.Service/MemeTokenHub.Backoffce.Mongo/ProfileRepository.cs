using Microsoft.Extensions.Options;
using MemeTokenHub.Backoffce.Mongo.Interfaces;
using MongoDB.Driver;
using Meme.Domain.Models;

namespace MemeTokenHub.Backoffce.Mongo
{
    public class ProfileRepository : IRepository<ProfileModel>
    {
        private readonly IMongoCollection<ProfileModel> _collection;
        private readonly MongoClient _client;

        public ProfileRepository(IOptions<MongoSettings> settings)
        {
            _client = new MongoClient(
            settings.Value.ConnectionString);

            var mongoDatabase = _client.GetDatabase(Constants.DatabaseName);

            _collection = mongoDatabase.GetCollection<ProfileModel>(Constants.ProfileCollection);
        }

        public Task<IEnumerable<ProfileModel>> GetByFilter(Func<ProfileModel, bool> filter)
        {
            return Task.FromResult(_collection.AsQueryable().Where(filter));
        }
    }
}