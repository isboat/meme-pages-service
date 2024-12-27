using Meme.Domain.Models;

namespace MemeTokenHub.Backoffce.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileModel?> GetByIdAsync(string profileId);
    }
}
