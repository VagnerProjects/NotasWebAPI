using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotasWebAPI.Migrations
{
    public partial class Enderecouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Endereco",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_UsuarioId",
                table: "Endereco",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Usuario_UsuarioId",
                table: "Endereco",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Usuario_UsuarioId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_UsuarioId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Endereco");
        }
    }
}
