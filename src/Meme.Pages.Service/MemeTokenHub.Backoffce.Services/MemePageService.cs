using Meme.Domain.Models;
using MemeTokenHub.Backoffce.Mongo.Interfaces;
using MemeTokenHub.Backoffce.Services.Interfaces;
using System;

namespace MemeTokenHub.Backoffce.Services
{
    public class MemePageService: IMemePageService
    {
        private readonly IRepository<MemePageModel> _repository;

        public MemePageService(IRepository<MemePageModel> repository)
        {
            _repository = repository;
        }


        public async Task<MemePageModel?> GetByPathUrlAsync(string pathUrl)
        {
            if (string.IsNullOrEmpty(pathUrl)) return null;

            return (await _repository.GetByFilter((x) => !string.IsNullOrEmpty(x.PathUrl) && x.PathUrl.ToLowerInvariant() == pathUrl.ToLowerInvariant())).FirstOrDefault();
        }
    }
}