using Microsoft.Azure.Cosmos.Table;

namespace BackendServer.Data;

/// <summary>
/// Provides a simple method for reading and writing entities to an Azure Storage Table
/// </summary>
public interface ISimpleDb
{
    /// <summary>
    /// Returns an entity with the specified partition key and row key
    /// </summary>
    Task<T> GetEntity<T>(string partitionKey, string rowKey) where T: ITableEntity, new();
    
    /// <summary>
    /// Returns all entities that share the specified parition key
    /// </summary>
    Task<IEnumerable<T>> GetEntities<T>(string partitionKey);
    
    /// <summary>
    /// Saves the specified entity in the database 
    /// </summary>
    Task SaveEntity(ITableEntity entity);    
}