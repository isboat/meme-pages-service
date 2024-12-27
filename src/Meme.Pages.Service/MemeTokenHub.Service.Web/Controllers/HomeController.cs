using MemeTokenHub.Backoffce.Services.Interfaces;
using MemeTokenHub.Service.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MemeTokenHub.Service.Web.Controllers
{
    /*
     eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjcmVhdGVkQXQiOjE3MzQ2MDEzMDI3NjUsImVtYWlsIjoicG9ua2F5MTAwQHlhaG9vLmNvbSIsImFjdGlvbiI6InRva2VuLWFwaSIsImFwaVZlcnNpb24iOiJ2MiIsImlhdCI6MTczNDYwMTMwMn0.Mf6NqjBhtsczcuPpoxEFT7orKigEXxc6Ai5cWzUhre0
     */

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenService _tokenService;

        public HomeController(ILogger<HomeController> logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new TokensViewModel
            {
                UnclaimedTokens = await _tokenService.GetUnclaimedTokensAsync(),
                ClaimedTokens = await _tokenService.GetClaimedTokensAsync()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
