using Microsoft.EntityFrameworkCore.Migrations;

namespace TestBancoPichincha.Api.Cliente.Migrations
{
    public partial class MigracionPostgresInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Genero = table.Column<string>(maxLength: 1, nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Identificacion = table.Column<string>(maxLength: 13, nullable: false),
                    Direccion = table.Column<string>(maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(maxLength: 12, nullable: false),
                    Contrasenia = table.Column<string>(maxLength: 10, nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
