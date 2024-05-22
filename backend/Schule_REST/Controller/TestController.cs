using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Schule_REST.Database;
using Schule_REST.Model;
using System;

namespace Schule_REST.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public DatabaseContext DatabaseContext { get; set; }
        public TestController(
            DatabaseContext db
            )
        {
            DatabaseContext = db;
        }

        [HttpGet("test/{id}")]
        public ActionResult<string> GetTest(int id)
        {
            //HttpClient client = new HttpClient();
            //string uri = "";
            //HttpResponseMessage response = await client.SendAsync(new HttpRequestMessage
            //{
            //    Method = new HttpMethod("GET"),
            //    RequestUri = new Uri(uri)
            //});
            //var a = JsonConvert.DeserializeObject<object>(await response.Content.ReadAsStringAsync());
            return Ok("42");
        }
    }
}
