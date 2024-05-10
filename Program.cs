using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var redisConnection = ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
