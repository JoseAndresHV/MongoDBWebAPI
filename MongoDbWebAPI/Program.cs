using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDatabaseOptions>(
    builder.Configuration.GetSection(nameof(MongoDatabaseOptions)));

builder.Services.AddSingleton<AccountService>();
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<TransactionService>();

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

app.MapControllers();

app.Run();
