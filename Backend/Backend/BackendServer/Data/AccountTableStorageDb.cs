using Microsoft.Azure.Cosmos.Table;

namespace BackendServer.Data
{
    public class AccountTableStorageDb : ISimpleDb
    {
        public static string TableName = "accounts";

        private readonly CloudTableClient _client;
        private CloudTable? _table = null;

        public AccountTableStorageDb(CloudTableClient client)
        {
            _client = client;
        }

        private async Task<CloudTable> ResolveTableAsync()
        {
            return await ResolveTableAsync(TableName);
        }

        private readonly SemaphoreSlim _tableLock = new(1);
        private async Task<CloudTable> ResolveTableAsync(string name)
        {
            if (_table != null) return _table;
            await _tableLock.WaitAsync();
            try
            {
                if (_table != null) return _table;
                var table = _client.GetTableReference(name);
                if (!await table.ExistsAsync())
                    await table.CreateIfNotExistsAsync();
                _table = table;
                return _table;
            }
            finally
            {
                _tableLock.Release();
            }
        }

        public async Task<T> GetEntity<T>(string partitionKey, string rowKey) where T : ITableEntity, new()
        {
            var table = await ResolveTableAsync();
            var op = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var res = await table.ExecuteAsync(op);
            return (T)res.Result;
        }

        public Task<IEnumerable<T>> GetEntities<T>(string partitionKey)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntity(ITableEntity entity)
        {

            return Task.Run(async () =>
            {
                var table = await ResolveTableAsync();
                TableOperation op = TableOperation.Insert(entity);
                var res = await table.ExecuteAsync(op);
            });
        }
    }
}
