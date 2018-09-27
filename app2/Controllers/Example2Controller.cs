using Microsoft.AspNetCore.Mvc;

namespace app2.Controllers
{
    [Route("/doit")]
    [ApiController]
    public class Example1Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var val1 = Request.Headers["ExampleAttribute1"];
            if (!string.IsNullOrEmpty(val1))
            {
                NewRelic.Api.Agent.NewRelic.AddCustomParameter("ExampleAttribute1", val1);
            }
            var val2 = Request.Headers["ExampleAttribute2"];
            if (!string.IsNullOrEmpty(val2))
            {
                NewRelic.Api.Agent.NewRelic.AddCustomParameter("ExampleAttribute2", val2);
            }
            return "Ok";
        }
    }
}