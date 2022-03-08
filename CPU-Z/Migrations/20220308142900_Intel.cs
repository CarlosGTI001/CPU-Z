using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPU_Z.Migrations
{
    public partial class Intel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPU_Z_Intel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Litografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arquitectura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    precioLanzamiento = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nucleos = table.Column<int>(type: "int", nullable: false),
                    Hilos = table.Column<int>(type: "int", nullable: false),
                    FrecuenciaBase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaTurbo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelojBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MultiplicadorReloj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cacheL1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cacheL2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cacheL3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamDDR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPU_Z_Intel", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPU_Z_Intel");
        }
    }
}
