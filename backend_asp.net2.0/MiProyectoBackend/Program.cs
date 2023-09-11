using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore; // Agrega este using para DbContextOptionsBuilder
using Microsoft.EntityFrameworkCore.SqlServer; // Agrega este using para UseSqlServer

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Agregar configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevServer",
        builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
});

// Agregar configuración de Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Title",
        Version = "v1"
    });
});

// Add DbContext configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Title V1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Habilitar CORS
app.UseCors("AllowAngularDevServer");

app.MapControllers();

app.Run();
