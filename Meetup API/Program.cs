using Meetup_API.EventData;
using Meetup_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("EventContextConnectionString");
builder.Services.AddDbContextPool<EventContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddSingleton<IEventData, MockEventData>();
builder.Services.AddScoped<IEventData, SqlEventData>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
