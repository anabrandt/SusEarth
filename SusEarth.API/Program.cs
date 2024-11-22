using Microsoft.EntityFrameworkCore;
using SusEarth.API.Data;
using SusEarth.API.Services;
using SusEarth.Services;
using SusEarth.API.Services.CEP;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OracleDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"))
           .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddScoped<ICEPService, CEPService>();

builder.Services.AddSingleton<MetroService>();

// Adiciona os controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
