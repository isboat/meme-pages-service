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
            return cacheData;
            //return cacheData.Where(x => x.CreationDate >  DateTime.UtcNow).ToList();
        }

        public async Task<IEnumerable<TokenDataModel>?> GetUnclaimedTokensAsync()
        {
            return await Task.FromResult(new List<TokenDataModel>());
        }
    }
}