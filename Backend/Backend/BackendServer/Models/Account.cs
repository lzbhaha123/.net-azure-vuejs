using Azure;
using Microsoft.Azure.Cosmos.Table;

namespace BackendServer.Models
{
    public class ApiAccount
    {
        public string Username { get; set; }
        public String FullName { get; set; }
    }
    public class Account : TableEntity
    {
        public string Username { get; set; }
        public String FullName { get; set; }




    }
}
