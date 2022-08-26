using Microsoft.AspNetCore.Mvc;
using BackendServer.Data;
using BackendServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        // GET: api/<ToDoItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ToDoItemController>/username/fullname
        [HttpGet("{username}")]
        public async Task<IEnumerable<ToDoItem>> Get(string username)
        {
            var items = await CloudTableHelper.toDoItems.GetEntities<ToDoItem>(username);
            return items;
        }

        // POST api/<ToDoItemController>
        [HttpPost]
        public async Task<IEnumerable<ToDoItem>> Post([FromBody] ToDoItem toDoItem)
        {
            await CloudTableHelper.toDoItems.SaveEntity(toDoItem);
            var items = await CloudTableHelper.toDoItems.GetEntities<ToDoItem>(toDoItem.PartitionKey);
            return items;

        }

        // PUT api/<ToDoItemController>
        [HttpPut]
        public async Task<IEnumerable<ToDoItem>> Put([FromBody] ToDoItem toDoItem)
        {
            await CloudTableHelper.toDoItems.SaveEntity(toDoItem);
            var items = await CloudTableHelper.toDoItems.GetEntities<ToDoItem>(toDoItem.PartitionKey);
            return items;
        }

        // DELETE api/<ToDoItemController>
        [HttpDelete]
        public async Task<IEnumerable<ToDoItem>> Delete([FromBody] ToDoItem toDoItem)
        {
            await CloudTableHelper.toDoItems.RemoveEntity(toDoItem);
            var items = await CloudTableHelper.toDoItems.GetEntities<ToDoItem>(toDoItem.PartitionKey);
            return items;
        }
    }
}
