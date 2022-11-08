using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Migrations
{
  public partial class DB : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
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

      migrationBuilder.CreateTable(
          name: "users",
          columns: table => new
          {
            UserId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Arroba = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            ModuloId = table.Column<int>(type: "int", nullable: false),
            Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_users", x => x.UserId);
            table.ForeignKey(
                      name: "FK_users_modulos_ModuloId",
                      column: x => x.ModuloId,
                      principalTable: "modulos",
                      principalColumn: "ModuloId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "posts",
          columns: table => new
          {
            PostId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            Likes = table.Column<int>(type: "int", nullable: false),
            UserId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_posts", x => x.PostId);
            table.ForeignKey(
                      name: "FK_posts_users_UserId",
                      column: x => x.UserId,
                      principalTable: "users",
                      principalColumn: "UserId",
                      onDelete: ReferentialAction.Cascade);
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
          name: "IX_posts_UserId",
          table: "posts",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_users_ModuloId",
          table: "users",
          column: "ModuloId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "posts");

      migrationBuilder.DropTable(
          name: "users");

      migrationBuilder.DropTable(
          name: "modulos");
    }
  }
}
