global using LMG.DAT.DataContext;
global using Microsoft.EntityFrameworkCore;
using LMG.DAT.Interfaces;
using LMG.DAT.Repositories;
using LMG.DAT.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient(typeof(LMG.DAT.Interfaces.GenericRepository<>), typeof(LMG.DAT.Repositories.GenericRepository<>));
builder.Services.AddTransient<IGeneralUnitOfWork, GeneralUnitOfWork>();
builder.Services.AddDbContext<LMG_DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
