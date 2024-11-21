using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using MemeTokenHub.Backoffce.Models;
using MemeTokenHub.Backoffce.Services;
using MemeTokenHub.Backoffce.Services.Interfaces;
using Partners.Management.Web.Models;

namespace Partners.Management.Web.Controllers
{
    [Route("{pathUrl}")]
    public class MemePagesController: Controller
    {
        private readonly IMemePageService _memePageService;

        public MemePagesController(IMemePageService tenantService)
        {
            _memePageService = tenantService;
        }

        [HttpGet("")]
        public async Task<ActionResult> Index(string pathUrl)
        {
            var model = await _memePageService.GetByPathUrlAsync(pathUrl);
            if(model == null) RedirectToAction("Index", nameof(HomeController));
            return View(model);
        }
    }
}
