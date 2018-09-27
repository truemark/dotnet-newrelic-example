using Microsoft.AspNetCore.Mvc;

namespace app2.Controllers
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