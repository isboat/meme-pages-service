using Meme.Domain.Models;
using MemeTokenHub.Backoffce.Mongo.Interfaces;
using MemeTokenHub.Backoffce.Services.Interfaces;

namespace MemeTokenHub.Backoffce.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository<ProfileModel> _repository;

        public ProfileService(IRepository<ProfileModel> repository)
        {
            _repository = repository;
        }


        public async Task<ProfileModel?> GetByIdAsync(string profileId)
        {
            if (string.IsNullOrEmpty(profileId)) return null;

            return (await _repository.GetByFilter((x) => !string.IsNullOrEmpty(x.Id) && x.Id.ToLowerInvariant() == profileId.ToLowerInvariant())).FirstOrDefault();
        }
    }
}