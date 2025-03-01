using MemeTokenHub.Service.Models;

namespace MemeTokenHub.Backoffce.Services.Interfaces
{
    public interface ITemplateService
    {
        Task<IEnumerable<TemplateModel>> GetTemplates();
    }
}
