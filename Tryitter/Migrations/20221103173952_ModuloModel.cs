using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Migrations
{
  public partial class ModuloModel : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Title",
          table: "posts");

      migrationBuilder.AddColumn<string>(
          name: "Arroba",
          table: "users",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "");

      migrationBuilder.AddColumn<DateTime>(
          name: "CreatedAt",
          table: "users",
          type: "datetime2",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

      migrationBuilder.AddColumn<string>(
          name: "Img",
          table: "users",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "");

      migrationBuilder.AddColumn<int>(
          name: "ModuloId",
          table: "users",
          type: "int",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<DateTime>(
          name: "CreatedAt",
          table: "posts",
          type: "datetime2",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

      migrationBuilder.AddColumn<int>(
          name: "Likes",
          table: "posts",
          type: "int",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.CreateTable(
          name: "modulos",
          columns: table => new
          {
            ModuloId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_modulos", x => x.ModuloId);
          });

      migrationBuilder.InsertData(
          table: "modulos",
          columns: new[] { "ModuloId", "Name" },
          values: new object[,]
          {
                    { 1, "Fundamentos" },
                    { 2, "Front-end" },
                    { 3, "Back-end" },
                    { 4, "Ciência da Computação" }
          });

      migrationBuilder.CreateIndex(
          name: "IX_users_ModuloId",
          table: "users",
          column: "ModuloId");

      migrationBuilder.AddForeignKey(
          name: "FK_users_modulos_ModuloId",
          table: "users",
          column: "ModuloId",
          principalTable: "modulos",
          principalColumn: "ModuloId",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_users_modulos_ModuloId",
          table: "users");

      migrationBuilder.DropTable(
          name: "modulos");

      migrationBuilder.DropIndex(
          name: "IX_users_ModuloId",
          table: "users");

      migrationBuilder.DropColumn(
          name: "Arroba",
          table: "users");

      migrationBuilder.DropColumn(
          name: "CreatedAt",
          table: "users");

      migrationBuilder.DropColumn(
          name: "Img",
          table: "users");

      migrationBuilder.DropColumn(
          name: "ModuloId",
          table: "users");

      migrationBuilder.DropColumn(
          name: "CreatedAt",
          table: "posts");

      migrationBuilder.DropColumn(
          name: "Likes",
          table: "posts");

      migrationBuilder.AddColumn<string>(
          name: "Title",
          table: "posts",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "");
    }
  }
}
