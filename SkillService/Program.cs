using Microsoft.EntityFrameworkCore;
using SkillService.Configurations;
using SkillService.Data;
using Core.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDb<SkillDbContext>(builder.Configuration.GetConnectionString("SkillsConn"));
builder.Services.AddServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.Seed();

app.Run();
