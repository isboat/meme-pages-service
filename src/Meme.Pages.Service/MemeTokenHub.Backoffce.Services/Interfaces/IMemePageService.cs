using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meme.Domain.Models;
using MemeTokenHub.Backoffce.Services;

namespace MemeTokenHub.Backoffce.Services.Interfaces
{
    public interface IMemePageService
    {
        Task<MemePageModel?> GetByPathUrlAsync(string pathUrl);
    }
}
