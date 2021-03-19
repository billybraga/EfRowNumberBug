using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfRowNumberBug.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OptionalChildren",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalChildren", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionalChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_OptionalChildren_OptionalChildId",
                        column: x => x.OptionalChildId,
                        principalTable: "OptionalChildren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "OptionalChildId" },
                values: new object[] { new Guid("af8451c3-61cb-4eda-8282-92250d85ef03"), null });

            migrationBuilder.CreateIndex(
                name: "IX_Parents_OptionalChildId",
                table: "Parents",
                column: "OptionalChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "OptionalChildren");
        }
    }
}
