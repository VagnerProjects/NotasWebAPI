using Microsoft.EntityFrameworkCore.Migrations;

namespace NotasWebAPI.Migrations
{
    public partial class Reformulando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Usuario",
                nullable: true);
        }
    }
}
