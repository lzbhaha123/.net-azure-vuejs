using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure; 
using BackendServer.Data;

var builder = WebApplication.CreateBuilder(args);

//CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(builder.Configuration.GetConnectionString("AzureTableConnection")));

var storageCredentials = new StorageCredentials("account", "key");
var cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);


CloudTableHelper.accounts = new AccountTableStorageDb(cloudStorageAccount.CreateCloudTableClient());
CloudTableHelper.toDoItems = new ToDoListTableStorageDb(cloudStorageAccount.CreateCloudTableClient());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("CustomerHeader");
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowCors");

app.MapControllers();

app.Run();