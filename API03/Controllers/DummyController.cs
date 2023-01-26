using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API03.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private HttpClient _client;

        public DummyController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("dummy-api");
        }


        // GET: api/<DummyController>
        [HttpGet]
        public async Task<string> Get()
        {
            return await _client.GetStringAsync("user");
        }

        // GET api/<DummyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DummyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DummyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DummyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
