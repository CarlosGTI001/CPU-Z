// <auto-generated />
using System;
using CPU_Z.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPU_Z.Migrations
{
    [DbContext(typeof(CPU_ZContext))]
    [Migration("20220308151441_AMD")]
    partial class AMD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CPU_Z.Models.CPU_Z_AMD", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Arquitectura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrecuenciaBase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrecuenciaTurbo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hilos")
                        .HasColumnType("int");

                    b.Property<string>("Litografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nucleos")
                        .HasColumnType("int");

                    b.Property<string>("RamDDR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Socket")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cacheL1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cacheL2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cacheL3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaLanzamiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("imgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precioLanzamiento")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ID");

                    b.ToTable("CPU_Z_AMD");
                });

            modelBuilder.Entity("CPU_Z.Models.CPU_Z_Intel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Arquitectura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrecuenciaBase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrecuenciaTurbo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hilos")
                        .HasColumnType("int");

                    b.Property<string>("Litografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MultiplicadorReloj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nucleos")
                        .HasColumnType("int");

                    b.Property<string>("RamDDR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelojBase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Socket")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cacheL1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cacheL2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cacheL3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaLanzamiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("imgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precioLanzamiento")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ID");

                    b.ToTable("CPU_Z_Intel");
                });
#pragma warning restore 612, 618
        }
    }
}
