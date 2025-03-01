using Meme.Domain.Models.TokenModels;
using MemeTokenHub.Backoffce.Services.Interfaces;

namespace MemeTokenHub.Backoffce.Services
{
    public class TokenService : ITokenService
    {
        private readonly IReadonlyCacheService _cacheService;

        public TokenService(IReadonlyCacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<IEnumerable<TokenDataModel>?> GetClaimedTokensAsync()
        {
            var cacheData = await _cacheService.GetItemsFromList<TokenDataModel>() ?? [];
            if (!cacheData.Any()) 
            { 
                cacheData.Add(new TokenDataModel {  Name = "Savior Coin", Description = "For saving people"});
                cacheData.Add(new TokenDataModel {  Name = "Trump Coin", Description = "Dummy coin for dummy people"});
            }

            return cacheData;
            //return cacheData.Where(x => x.CreationDate >  DateTime.UtcNow).ToList();
        }

        public async Task<IEnumerable<TokenDataModel>?> GetUnclaimedTokensAsync()
        {
            return await Task.FromResult(new List<TokenDataModel> 
            {  
                new TokenDataModel { Name = "TEst", Description = "Some description of the token here"},
                new TokenDataModel { Name = "Flower pot meme", Description = "Some description of the flower pot token here"},
            });
        }
    }
}