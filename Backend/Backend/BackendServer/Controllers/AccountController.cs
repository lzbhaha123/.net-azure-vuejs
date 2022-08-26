using Microsoft.AspNetCore.Mvc;
using BackendServer.Data;
using BackendServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/username/fullname
        [HttpGet("{username}/{fullName}")]
        public async Task<Account> Get(string username,string fullName)
        {
            Account account = await CloudTableHelper.accounts.GetEntity<Account>(username, fullName);
            return account;
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] Account account)
        {
            
            CloudTableHelper.accounts.SaveEntity(account);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
