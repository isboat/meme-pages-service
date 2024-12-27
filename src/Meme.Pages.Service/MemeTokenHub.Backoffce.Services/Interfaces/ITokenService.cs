using Meme.Domain.Models.TokenModels;

namespace MemeTokenHub.Backoffce.Services.Interfaces
{
    public interface ITokenService
    {
        Task<IEnumerable<TokenDataModel>?> GetUnclaimedTokensAsync();

        Task<IEnumerable<TokenDataModel>?> GetClaimedTokensAsync();
    }
}
