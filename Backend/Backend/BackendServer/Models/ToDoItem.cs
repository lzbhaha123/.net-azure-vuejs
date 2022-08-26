using Azure;
using Microsoft.Azure.Cosmos.Table;

namespace BackendServer.Models
{

    public class ToDoItem : TableEntity
    {
        public bool IsDone { get; set; }
        public string Context { get; set; }

    }
}
