using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(p =>
  p.AddPolicy("corsapp", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

builder.Services.AddDbContext<DataContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("Default Connection")));

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});
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

app.UseCors("corsapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
