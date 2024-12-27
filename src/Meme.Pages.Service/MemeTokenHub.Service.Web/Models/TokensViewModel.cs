using Meme.Domain.Models.TokenModels;

namespace MemeTokenHub.Service.Web.Models
{
    public class TokensViewModel
    {
        public IEnumerable<TokenDataModel>? UnclaimedTokens { get; set; }

        public IEnumerable<TokenDataModel>? ClaimedTokens { get; set; }
    }
}
