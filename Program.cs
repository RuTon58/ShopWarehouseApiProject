using Microsoft.EntityFrameworkCore;
using ShopApi.Core.Application.Data;
using ShopApi.Core.Application.Intefaces;
using ShopApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IWareUnitTypeRepository, WareUtitTypeRepository>();
builder.Services.AddScoped<IWareRepository, WareRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
