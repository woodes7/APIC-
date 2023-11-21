using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Contexto.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesos",
                columns: table => new
                {
                    IdAcceso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoAcceso = table.Column<string>(type: "text", nullable: true),
                    DescripcionAcceso = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.IdAcceso);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreAutor = table.Column<string>(type: "text", nullable: false),
                    ApellidosAutor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Colecciones",
                columns: table => new
                {
                    IdColeccion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreColeccion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecciones", x => x.IdColeccion);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreEditorial = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "EstadosPrestamos",
                columns: table => new
                {
                    IdEstadoPrestamo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoEstadoPrestamo = table.Column<string>(type: "text", nullable: false),
                    DescripcionEstadoPrestamo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosPrestamos", x => x.IdEstadoPrestamo);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreGenero = table.Column<string>(type: "text", nullable: true),
                    DescripcionGenero = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dni = table.Column<string>(type: "text", nullable: false),
                    Napellidos = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Clave = table.Column<string>(type: "text", nullable: false),
                    IdAcceso = table.Column<int>(type: "integer", nullable: false),
                    idAcceso = table.Column<int>(type: "integer", nullable: false),
                    EstaBloqueadoUsuario = table.Column<bool>(type: "boolean", nullable: true),
                    FchFinBloqueoUsuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FchAltaUsuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FchBajaUsuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Accesos_idAcceso",
                        column: x => x.idAcceso,
                        principalTable: "Accesos",
                        principalColumn: "IdAcceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsbnLibro = table.Column<string>(type: "text", nullable: true),
                    TituloLibro = table.Column<string>(type: "text", nullable: true),
                    EdicionLibro = table.Column<string>(type: "text", nullable: true),
                    CantidadLibro = table.Column<int>(type: "integer", nullable: true),
                    IdEditorial = table.Column<int>(type: "integer", nullable: false),
                    id_editorial = table.Column<int>(type: "integer", nullable: false),
                    IdGenero = table.Column<int>(type: "integer", nullable: false),
                    id_genero = table.Column<int>(type: "integer", nullable: false),
                    IdColeccion = table.Column<int>(type: "integer", nullable: false),
                    id_coleccion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Colecciones_id_coleccion",
                        column: x => x.id_coleccion,
                        principalTable: "Colecciones",
                        principalColumn: "IdColeccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_id_editorial",
                        column: x => x.id_editorial,
                        principalTable: "Editoriales",
                        principalColumn: "IdEditorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Generos_id_genero",
                        column: x => x.id_genero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutorLibro",
                columns: table => new
                {
                    AutoresIdAutor = table.Column<int>(type: "integer", nullable: false),
                    ListaLibrosIdLibro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLibro", x => new { x.AutoresIdAutor, x.ListaLibrosIdLibro });
                    table.ForeignKey(
                        name: "FK_AutorLibro_Autores_AutoresIdAutor",
                        column: x => x.AutoresIdAutor,
                        principalTable: "Autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLibro_Libros_ListaLibrosIdLibro",
                        column: x => x.ListaLibrosIdLibro,
                        principalTable: "Libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_usuario = table.Column<int>(type: "integer", nullable: false),
                    idUsuario = table.Column<int>(type: "integer", nullable: false),
                    EstadoPrestamoIdEstadoPrestamo = table.Column<int>(type: "integer", nullable: false),
                    FchaInicPrestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FchFinPrestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FchEtregPrestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IdEstadoPrestamo = table.Column<int>(type: "integer", nullable: false),
                    LibroIdLibro = table.Column<int>(type: "integer", nullable: true),
                    idEstadoPrestamo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_EstadosPrestamos_EstadoPrestamoIdEstadoPrestamo",
                        column: x => x.EstadoPrestamoIdEstadoPrestamo,
                        principalTable: "EstadosPrestamos",
                        principalColumn: "IdEstadoPrestamo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Libros_LibroIdLibro",
                        column: x => x.LibroIdLibro,
                        principalTable: "Libros",
                        principalColumn: "IdLibro");
                    table.ForeignKey(
                        name: "FK_Prestamos_Prestamos_idEstadoPrestamo",
                        column: x => x.idEstadoPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamo");
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelaccionAutoresLibros",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "integer", nullable: false),
                    IdLibro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaccionAutoresLibros", x => new { x.IdAutor, x.IdLibro });
                    table.ForeignKey(
                        name: "FK_RelaccionAutoresLibros_Autores_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "Autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelaccionAutoresLibros_Libros_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelaccionLibrosPrestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "integer", nullable: false),
                    IdLibro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaccionLibrosPrestamos", x => new { x.IdPrestamo, x.IdLibro });
                    table.ForeignKey(
                        name: "FK_RelaccionLibrosPrestamos_Libros_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelaccionLibrosPrestamos_Prestamos_IdPrestamo",
                        column: x => x.IdPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorLibro_ListaLibrosIdLibro",
                table: "AutorLibro",
                column: "ListaLibrosIdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_id_coleccion",
                table: "Libros",
                column: "id_coleccion");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_id_editorial",
                table: "Libros",
                column: "id_editorial");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_id_genero",
                table: "Libros",
                column: "id_genero");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_EstadoPrestamoIdEstadoPrestamo",
                table: "Prestamos",
                column: "EstadoPrestamoIdEstadoPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_idEstadoPrestamo",
                table: "Prestamos",
                column: "idEstadoPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_idUsuario",
                table: "Prestamos",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_LibroIdLibro",
                table: "Prestamos",
                column: "LibroIdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_RelaccionAutoresLibros_IdLibro",
                table: "RelaccionAutoresLibros",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_RelaccionLibrosPrestamos_IdLibro",
                table: "RelaccionLibrosPrestamos",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idAcceso",
                table: "Usuario",
                column: "idAcceso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorLibro");

            migrationBuilder.DropTable(
                name: "RelaccionAutoresLibros");

            migrationBuilder.DropTable(
                name: "RelaccionLibrosPrestamos");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "EstadosPrestamos");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Colecciones");

            migrationBuilder.DropTable(
                name: "Editoriales");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Accesos");
        }
    }
}
