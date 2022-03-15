using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestBancoPichincha.Api.Movimientos.Migrations
{
    public partial class MigracionPostgresInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    MovimientoId = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(maxLength: 10, nullable: false),
                    Tipo = table.Column<string>(maxLength: 20, nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Saldo = table.Column<double>(nullable: false),
                    CuentaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.MovimientoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");
        }
    }
}
