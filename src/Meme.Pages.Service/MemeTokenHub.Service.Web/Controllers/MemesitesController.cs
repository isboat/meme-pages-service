using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemeTokenHub.Service.Web.Controllers
{
    [Route("memesites")]
    public class MemesitesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet("deploy")]
        public ActionResult Deploy()
        {
            return View();
        }

        [HttpGet("deploy/manual")]
        public ActionResult DeployManual()
        {
            return View();
        }

    }
}
