using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestBancoPichincha.Api.Cuenta.Migrations
{
    public partial class MigracionPostgresInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    CuentaId = table.Column<string>(nullable: false),
                    NumeroCuenta = table.Column<string>(maxLength: 10, nullable: false),
                    Tipo = table.Column<string>(maxLength: 20, nullable: false),
                    SaldoInicial = table.Column<double>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.CuentaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}
