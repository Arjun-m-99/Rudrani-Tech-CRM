using Microsoft.EntityFrameworkCore;
using Rudrani_Tech_CRM.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding Connection String
builder.Services.AddDbContext<RudraniCrmContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o=>o.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo
{
    Title ="Create lead",
    Version= "v1",
    Description="desc1"
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o=>o.SwaggerEndpoint("/swagger/v1/swagger.json","create lead Api"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
