using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Mappers;
using ToDoListAPI.Persistence;
using ToDoListAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<ToDoDbContext>();
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<ToDoDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddAutoMapper(typeof(ToDoProfile));
builder.Services.AddScoped<ToDoService>();

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
