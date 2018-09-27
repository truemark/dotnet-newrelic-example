using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
    [Route("/healthcheck")]
    [ApiController]
    public class HealthCheckController : Controller
    {
        // GET
        public ActionResult<string> Check()
        {
            return "Ok";
        }
    }
}