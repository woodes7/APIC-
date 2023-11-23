using Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar controladores a la aplicación
builder.Services.AddControllers();
// Agregar servicios para la generación de documentación Swagger/OpenAPI https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurar y agregar el contexto de base de datos a través de Entity Framework Core
builder.Services.AddDbContext<ApiDBContexto>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionStr"));
});

var app = builder.Build();
// Aplicar migraciones al iniciar la aplicación para garantizar que la base de datos esté actualizada
using (var scope = app.Services.CreateScope())
{
    var contexto = scope.ServiceProvider.GetRequiredService<ApiDBContexto>();
    contexto.Database.Migrate();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   // Habilitar Swagger para entornos de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
// Mapear los controladores en la aplicación
app.MapControllers();

app.Run();
