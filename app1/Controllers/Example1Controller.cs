using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
    [Route("/doit")]
    [ApiController]
    public class Example1Controller : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
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

            if (!string.IsNullOrEmpty(val2) && !string.IsNullOrEmpty(val1))
            {
                NewRelic.Api.Agent.NewRelic.AddCustomParameter("ExampleAttributes", val1 + "|" + val2);
            }
           

            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> task = client.GetAsync("http://app2:5000/doit?someparam1=" + val1 + "&somparam2=" + val2);
            HttpResponseMessage msg = await task;
            return await msg.Content.ReadAsStringAsync();
        }
    }
}