using Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar controladores a la aplicaci�n
builder.Services.AddControllers();
// Agregar servicios para la generaci�n de documentaci�n Swagger/OpenAPI https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurar y agregar el contexto de base de datos a trav�s de Entity Framework Core
builder.Services.AddDbContext<ApiDBContexto>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionStr"));
});

var app = builder.Build();
// Aplicar migraciones al iniciar la aplicaci�n para garantizar que la base de datos est� actualizada
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
// Mapear los controladores en la aplicaci�n
app.MapControllers();

app.Run();
