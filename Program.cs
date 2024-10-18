using backend_management_system_api.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext (Remove the duplicate registration)
builder.Services.AddDbContext<DbConfig>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ticket_Database")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // serializing Enum Status as strings;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Allow Any Cors Origin
app.UseCors(options=>{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();

});
// app.UseAuthorization();
app.MapControllers();
// Disable HTTPS redirection for local development
// Comment out or remove the following line if you don't need HTTPS redirection:
app.UseHttpsRedirection();

app.Run();
