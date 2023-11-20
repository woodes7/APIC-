﻿// <auto-generated />
using System;
using Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Contexto.Migrations
{
    [DbContext(typeof(ApiDBContexto))]
    partial class ApiDBContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutorLibro", b =>
                {
                    b.Property<int>("AutoresidAutor")
                        .HasColumnType("integer");

                    b.Property<int>("LibrosidLibro")
                        .HasColumnType("integer");

                    b.HasKey("AutoresidAutor", "LibrosidLibro");

                    b.HasIndex("LibrosidLibro");

                    b.ToTable("AutorLibro");
                });

            modelBuilder.Entity("Modelo.Acceso", b =>
                {
                    b.Property<int>("idAcceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idAcceso"));

                    b.Property<string>("codigoAcceso")
                        .HasColumnType("text");

                    b.Property<string>("descripcionAcceso")
                        .HasColumnType("text");

                    b.HasKey("idAcceso");

                    b.ToTable("Accesos", (string)null);
                });

            modelBuilder.Entity("Modelo.Autor", b =>
                {
                    b.Property<int>("idAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idAutor"));

                    b.Property<string>("apellidosAutor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nombreAutor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idAutor");

                    b.ToTable("Autores", (string)null);
                });

            modelBuilder.Entity("Modelo.Coleccion", b =>
                {
                    b.Property<int>("idColeccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idColeccion"));

                    b.Property<string>("nombreColeccion")
                        .HasColumnType("text");

                    b.HasKey("idColeccion");

                    b.ToTable("Colecciones", (string)null);
                });

            modelBuilder.Entity("Modelo.Editorial", b =>
                {
                    b.Property<int>("idEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idEditorial"));

                    b.Property<string>("nombreEditorial")
                        .HasColumnType("text");

                    b.HasKey("idEditorial");

                    b.ToTable("Editoriales", (string)null);
                });

            modelBuilder.Entity("Modelo.EstadoPrestamo", b =>
                {
                    b.Property<int>("idEstadoPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idEstadoPrestamo"));

                    b.Property<string>("codigoEstadoPrestamo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("descripcionEstadoPrestamo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idEstadoPrestamo");

                    b.ToTable("EstadosPrestamos", (string)null);
                });

            modelBuilder.Entity("Modelo.Genero", b =>
                {
                    b.Property<int>("idGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idGenero"));

                    b.Property<string>("descripcionGenero")
                        .HasColumnType("text");

                    b.Property<string>("nombreGenero")
                        .HasColumnType("text");

                    b.HasKey("idGenero");

                    b.ToTable("Generos", (string)null);
                });

            modelBuilder.Entity("Modelo.Libro", b =>
                {
                    b.Property<int>("idLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idLibro"));

                    b.Property<int?>("cantidadLibro")
                        .HasColumnType("integer");

                    b.Property<string>("edicionLibro")
                        .HasColumnType("text");

                    b.Property<int>("idColeccion")
                        .HasColumnType("integer");

                    b.Property<int>("idEditorial")
                        .HasColumnType("integer");

                    b.Property<int>("idGenero")
                        .HasColumnType("integer");

                    b.Property<int>("id_coleccion")
                        .HasColumnType("integer");

                    b.Property<int>("id_editorial")
                        .HasColumnType("integer");

                    b.Property<int>("id_genero")
                        .HasColumnType("integer");

                    b.Property<string>("isbnLibro")
                        .HasColumnType("text");

                    b.Property<string>("tituloLibro")
                        .HasColumnType("text");

                    b.HasKey("idLibro");

                    b.HasIndex("id_coleccion");

                    b.HasIndex("id_editorial");

                    b.HasIndex("id_genero");

                    b.ToTable("Libros", (string)null);
                });

            modelBuilder.Entity("Modelo.Prestamo", b =>
                {
                    b.Property<int>("id_prestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_prestamo"));

                    b.Property<int>("EstadoPrestamoidEstadoPrestamo")
                        .HasColumnType("integer");

                    b.Property<int?>("LibroidLibro")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("fch_entrega_prestamo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fch_fin_prestamo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fch_inicio_prestamo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("idEstadoPrestamo")
                        .HasColumnType("integer");

                    b.Property<int?>("id_estado_prestamo")
                        .HasColumnType("integer");

                    b.Property<int>("id_usuario")
                        .HasColumnType("integer");

                    b.HasKey("id_prestamo");

                    b.HasIndex("EstadoPrestamoidEstadoPrestamo");

                    b.HasIndex("LibroidLibro");

                    b.HasIndex("id_estado_prestamo");

                    b.HasIndex("id_usuario");

                    b.ToTable("Prestamos", (string)null);
                });

            modelBuilder.Entity("Modelo.RelaccionAutorLibro", b =>
                {
                    b.Property<int>("idAutor")
                        .HasColumnType("integer");

                    b.Property<int>("idLibro")
                        .HasColumnType("integer");

                    b.HasKey("idAutor", "idLibro");

                    b.HasIndex("idLibro");

                    b.ToTable("RelaccionAutoresLibros", (string)null);
                });

            modelBuilder.Entity("Modelo.RelaccionLibroPrestamo", b =>
                {
                    b.Property<int>("idPrestamo")
                        .HasColumnType("integer");

                    b.Property<int>("idLibro")
                        .HasColumnType("integer");

                    b.Property<int>("prestamoid_prestamo")
                        .HasColumnType("integer");

                    b.HasKey("idPrestamo", "idLibro");

                    b.HasIndex("idLibro");

                    b.HasIndex("prestamoid_prestamo");

                    b.ToTable("RelaccionLibrosPrestamos", (string)null);
                });

            modelBuilder.Entity("Modelo.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idUsuario"));

                    b.Property<string>("apellidos")
                        .HasColumnType("text");

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<bool?>("estaBloqueado_usuario")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("fchAltaUsuario")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fchBajaUsuario")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fchFinBloqueo_usuario")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("idAcceso")
                        .HasColumnType("integer");

                    b.Property<int>("id_acceso")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<string>("telefono")
                        .HasColumnType("text");

                    b.HasKey("idUsuario");

                    b.HasIndex("id_acceso");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("AutorLibro", b =>
                {
                    b.HasOne("Modelo.Autor", null)
                        .WithMany()
                        .HasForeignKey("AutoresidAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Libro", null)
                        .WithMany()
                        .HasForeignKey("LibrosidLibro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Modelo.Libro", b =>
                {
                    b.HasOne("Modelo.Coleccion", "Coleccion")
                        .WithMany("LibrosColeccion")
                        .HasForeignKey("id_coleccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Editorial", "Editorial")
                        .WithMany("LibrosEditorial")
                        .HasForeignKey("id_editorial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Genero", "Genero")
                        .WithMany("LibrosGenero")
                        .HasForeignKey("id_genero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coleccion");

                    b.Navigation("Editorial");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("Modelo.Prestamo", b =>
                {
                    b.HasOne("Modelo.EstadoPrestamo", "EstadoPrestamo")
                        .WithMany()
                        .HasForeignKey("EstadoPrestamoidEstadoPrestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Libro", null)
                        .WithMany("Prestamos")
                        .HasForeignKey("LibroidLibro");

                    b.HasOne("Modelo.Prestamo", null)
                        .WithMany("PrestamosLibros")
                        .HasForeignKey("id_estado_prestamo");

                    b.HasOne("Modelo.Usuario", "Usuarios")
                        .WithMany()
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoPrestamo");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Modelo.RelaccionAutorLibro", b =>
                {
                    b.HasOne("Modelo.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("idAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Libro", "Libro")
                        .WithMany()
                        .HasForeignKey("idLibro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Libro");
                });

            modelBuilder.Entity("Modelo.RelaccionLibroPrestamo", b =>
                {
                    b.HasOne("Modelo.Libro", "libro")
                        .WithMany()
                        .HasForeignKey("idLibro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.Prestamo", "prestamo")
                        .WithMany()
                        .HasForeignKey("prestamoid_prestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("libro");

                    b.Navigation("prestamo");
                });

            modelBuilder.Entity("Modelo.Usuario", b =>
                {
                    b.HasOne("Modelo.Acceso", "Acceso")
                        .WithMany("UsuariosConAcceso")
                        .HasForeignKey("id_acceso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acceso");
                });

            modelBuilder.Entity("Modelo.Acceso", b =>
                {
                    b.Navigation("UsuariosConAcceso");
                });

            modelBuilder.Entity("Modelo.Coleccion", b =>
                {
                    b.Navigation("LibrosColeccion");
                });

            modelBuilder.Entity("Modelo.Editorial", b =>
                {
                    b.Navigation("LibrosEditorial");
                });

            modelBuilder.Entity("Modelo.Genero", b =>
                {
                    b.Navigation("LibrosGenero");
                });

            modelBuilder.Entity("Modelo.Libro", b =>
                {
                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("Modelo.Prestamo", b =>
                {
                    b.Navigation("PrestamosLibros");
                });
#pragma warning restore 612, 618
        }
    }
}
