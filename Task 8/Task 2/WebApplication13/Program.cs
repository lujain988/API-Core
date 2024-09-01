using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApplication13.Models;
Log.Logger = new LoggerConfiguration()
   .WriteTo.Console()
   .WriteTo.File("Lujain.txt", rollingInterval: RollingInterval.Month)// Default file path);
   .CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));
builder.Services.AddMemoryCache();
builder.Services.AddCors(options => options.AddPolicy("Development", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();

})

);

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(); 

app.UseAuthorization();


app.MapControllers();
app.UseCors("Development");


app.Run();
