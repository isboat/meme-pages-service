using MemeTokenHub.Backoffce.Services.Interfaces;
using MemeTokenHub.Service.Models;

namespace MemeTokenHub.Backoffce.Services
{
    public class TemplateService : ITemplateService
    {
        public async Task<IEnumerable<TemplateModel>> GetTemplates()
        {
            var models = new List<TemplateModel>
            {
                new TemplateModel { Key = "simple", Label = "Simple"}
            };

            return await Task.FromResult(models);

        }
    }
}