using API03.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyNewController : ControllerBase
    {
        private DummyService _dummyService;

        public DummyNewController(DummyService dummyService)
        {
            _dummyService = dummyService;
        }


        // GET: api/<DummyNewController>
        [HttpGet]
        public async Task<string> Get()
        {
            return await _dummyService.Users();
        }

        // GET api/<DummyNewController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            return await _dummyService.User(id);
        }

        // POST api/<DummyNewController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DummyNewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DummyNewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
