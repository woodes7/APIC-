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
                    idAcceso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigoAcceso = table.Column<string>(type: "text", nullable: true),
                    descripcionAcceso = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.idAcceso);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    idAutor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombreAutor = table.Column<string>(type: "text", nullable: false),
                    apellidosAutor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.idAutor);
                });

            migrationBuilder.CreateTable(
                name: "Colecciones",
                columns: table => new
                {
                    idColeccion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombreColeccion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecciones", x => x.idColeccion);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    idEditorial = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombreEditorial = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.idEditorial);
                });

            migrationBuilder.CreateTable(
                name: "EstadosPrestamos",
                columns: table => new
                {
                    idEstadoPrestamo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigoEstadoPrestamo = table.Column<string>(type: "text", nullable: false),
                    descripcionEstadoPrestamo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosPrestamos", x => x.idEstadoPrestamo);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    idGenero = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombreGenero = table.Column<string>(type: "text", nullable: true),
                    descripcionGenero = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.idGenero);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dni = table.Column<string>(type: "text", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    apellidos = table.Column<string>(type: "text", nullable: true),
                    telefono = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    clave = table.Column<string>(type: "text", nullable: false),
                    idAcceso = table.Column<int>(type: "integer", nullable: false),
                    id_acceso = table.Column<int>(type: "integer", nullable: false),
                    estaBloqueado_usuario = table.Column<bool>(type: "boolean", nullable: true),
                    fchFinBloqueo_usuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fchAltaUsuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fchBajaUsuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Accesos_id_acceso",
                        column: x => x.id_acceso,
                        principalTable: "Accesos",
                        principalColumn: "idAcceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    idLibro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isbnLibro = table.Column<string>(type: "text", nullable: true),
                    tituloLibro = table.Column<string>(type: "text", nullable: true),
                    edicionLibro = table.Column<string>(type: "text", nullable: true),
                    cantidadLibro = table.Column<int>(type: "integer", nullable: true),
                    idEditorial = table.Column<int>(type: "integer", nullable: false),
                    id_editorial = table.Column<int>(type: "integer", nullable: false),
                    idGenero = table.Column<int>(type: "integer", nullable: false),
                    id_genero = table.Column<int>(type: "integer", nullable: false),
                    idColeccion = table.Column<int>(type: "integer", nullable: false),
                    id_coleccion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.idLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Colecciones_id_coleccion",
                        column: x => x.id_coleccion,
                        principalTable: "Colecciones",
                        principalColumn: "idColeccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_id_editorial",
                        column: x => x.id_editorial,
                        principalTable: "Editoriales",
                        principalColumn: "idEditorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Generos_id_genero",
                        column: x => x.id_genero,
                        principalTable: "Generos",
                        principalColumn: "idGenero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutorLibro",
                columns: table => new
                {
                    AutoresidAutor = table.Column<int>(type: "integer", nullable: false),
                    LibrosidLibro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLibro", x => new { x.AutoresidAutor, x.LibrosidLibro });
                    table.ForeignKey(
                        name: "FK_AutorLibro_Autores_AutoresidAutor",
                        column: x => x.AutoresidAutor,
                        principalTable: "Autores",
                        principalColumn: "idAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLibro_Libros_LibrosidLibro",
                        column: x => x.LibrosidLibro,
                        principalTable: "Libros",
                        principalColumn: "idLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    id_prestamo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    EstadoPrestamoidEstadoPrestamo = table.Column<int>(type: "integer", nullable: false),
                    fch_inicio_prestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fch_fin_prestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fch_entrega_prestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    idEstadoPrestamo = table.Column<int>(type: "integer", nullable: false),
                    LibroidLibro = table.Column<int>(type: "integer", nullable: true),
                    id_estado_prestamo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.id_prestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_EstadosPrestamos_EstadoPrestamoidEstadoPrestamo",
                        column: x => x.EstadoPrestamoidEstadoPrestamo,
                        principalTable: "EstadosPrestamos",
                        principalColumn: "idEstadoPrestamo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Libros_LibroidLibro",
                        column: x => x.LibroidLibro,
                        principalTable: "Libros",
                        principalColumn: "idLibro");
                    table.ForeignKey(
                        name: "FK_Prestamos_Prestamos_id_estado_prestamo",
                        column: x => x.id_estado_prestamo,
                        principalTable: "Prestamos",
                        principalColumn: "id_prestamo");
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelaccionAutoresLibros",
                columns: table => new
                {
                    idAutor = table.Column<int>(type: "integer", nullable: false),
                    idLibro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaccionAutoresLibros", x => new { x.idAutor, x.idLibro });
                    table.ForeignKey(
                        name: "FK_RelaccionAutoresLibros_Autores_idAutor",
                        column: x => x.idAutor,
                        principalTable: "Autores",
                        principalColumn: "idAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelaccionAutoresLibros_Libros_idLibro",
                        column: x => x.idLibro,
                        principalTable: "Libros",
                        principalColumn: "idLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelaccionLibrosPrestamos",
                columns: table => new
                {
                    idPrestamo = table.Column<int>(type: "integer", nullable: false),
                    idLibro = table.Column<int>(type: "integer", nullable: false),
                    prestamoid_prestamo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelaccionLibrosPrestamos", x => new { x.idPrestamo, x.idLibro });
                    table.ForeignKey(
                        name: "FK_RelaccionLibrosPrestamos_Libros_idLibro",
                        column: x => x.idLibro,
                        principalTable: "Libros",
                        principalColumn: "idLibro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelaccionLibrosPrestamos_Prestamos_prestamoid_prestamo",
                        column: x => x.prestamoid_prestamo,
                        principalTable: "Prestamos",
                        principalColumn: "id_prestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorLibro_LibrosidLibro",
                table: "AutorLibro",
                column: "LibrosidLibro");

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
                name: "IX_Prestamos_EstadoPrestamoidEstadoPrestamo",
                table: "Prestamos",
                column: "EstadoPrestamoidEstadoPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_id_estado_prestamo",
                table: "Prestamos",
                column: "id_estado_prestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_id_usuario",
                table: "Prestamos",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_LibroidLibro",
                table: "Prestamos",
                column: "LibroidLibro");

            migrationBuilder.CreateIndex(
                name: "IX_RelaccionAutoresLibros_idLibro",
                table: "RelaccionAutoresLibros",
                column: "idLibro");

            migrationBuilder.CreateIndex(
                name: "IX_RelaccionLibrosPrestamos_idLibro",
                table: "RelaccionLibrosPrestamos",
                column: "idLibro");

            migrationBuilder.CreateIndex(
                name: "IX_RelaccionLibrosPrestamos_prestamoid_prestamo",
                table: "RelaccionLibrosPrestamos",
                column: "prestamoid_prestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_id_acceso",
                table: "Usuario",
                column: "id_acceso");
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
