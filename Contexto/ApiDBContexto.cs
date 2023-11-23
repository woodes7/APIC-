using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Modelo;
using System.Configuration;

namespace Contexto
{
    public class ApiDBContexto : DbContext
    {
        // Constructor que recibe opciones de configuración para el contexto
        public ApiDBContexto(DbContextOptions<ApiDBContexto> opcion) : base(opcion)
        {

        }
        // Constructor vacío por defecto
        public ApiDBContexto()
        {
            
        }
        // Definición de DbSet para cada entidad del modelo
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Coleccion> Colecciones { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<EstadoPrestamo> EstadosPrestamos { get; set; }
        public DbSet<RelaccionAutorLibro> RelaccionAutoresLibros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<RelaccionLibroPrestamo> RelaccionLibrosPrestamos { get; set; }
        // Configuración de la conexión a la base de datos en el método OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   // Configuración de la conexión utilizando la cadena de conexión almacenada en appsettings.json
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("ConnectionStr"));
        }
        // Configuración de las relaciones y nombres de tabla en el método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Acceso>().ToTable("Accesos");
            modelBuilder.Entity<Libro>().ToTable("Libros");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Coleccion>().ToTable("Colecciones");
            modelBuilder.Entity<Editorial>().ToTable("Editoriales");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamos");
            modelBuilder.Entity<EstadoPrestamo>().ToTable("EstadosPrestamos");
            modelBuilder.Entity<RelaccionAutorLibro>().ToTable("RelaccionAutoresLibros");
            modelBuilder.Entity<Autor>().ToTable("Autores");
            modelBuilder.Entity<RelaccionLibroPrestamo>().ToTable("RelaccionLibrosPrestamos");
        }

    }
}
