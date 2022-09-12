using Core.Prueba.Interfaces;
using Infraestructure.Prueba.BDatos;
using Infraestructure.Prueba.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PRUEBAContext>(options => options.UseSqlServer(configuration.GetConnectionString("Prueba")));
//Dependencias
builder.Services.AddScoped<IMasterdataRepository, MasterdataRepository>();
builder.Services.AddScoped<IPatientsRepositorys, PatientsRepositorys>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IMasterRepository, MasterRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{ endpoints.MapControllers(); });
app.Run();
