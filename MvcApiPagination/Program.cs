using MvcApiPagination.Model.Core.Context;
using MvcApiPagination.Model.Core.Paginations;
using MvcApiPagination.Model.Paginations;
using MvcApiPagination.Model.Persistences;
using MvcApiPagination.Model.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Coneccion 
builder.Services.AddDbContext<ApplicationBbContext>();

// Registrar servicios del repositorio de model
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IFabricanteRepository, FabricanteRepository>();

// Registrar Servicios de Paginator
builder.Services.AddTransient(typeof(IPaginator<>), typeof(Paginator<>));

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
