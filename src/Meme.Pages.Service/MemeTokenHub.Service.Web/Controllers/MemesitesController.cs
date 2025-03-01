using MemeTokenHub.Backoffce.Services.Interfaces;
using MemeTokenHub.Service.Models;
using MemeTokenHub.Service.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemeTokenHub.Service.Web.Controllers
{
    [Route("memesites")]
    public class MemesitesController : Controller
    {
        private readonly ITemplateService _templateService;

        public MemesitesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        public ActionResult Index()
        {
            return View();
        }



        [HttpGet("deploy")]
        public ActionResult Deploy()
        {
            ViewData["Layout"] = "_MemeLayout";
            return View();
        }

        [HttpGet("deploy/manual")]
        public ActionResult DeployManual()
        {
            return View();
        }


        [HttpPost("deploy/manual")]
        public ActionResult PostDeployManual([FromForm] SiteCreationModel model)
        {
            HttpContext.Session.Set("CreationStepOne", model);
            //var ss = HttpContext.Session.Get<SiteCreationModel>("CreationStepOne");

            return Redirect("manual/template");
        }

        [HttpGet("deploy/manual/template")]
        public async Task<ActionResult> SelectTemplate()
        {
            var models = await _templateService.GetTemplates();
            return View(models);
        }

    }
}
