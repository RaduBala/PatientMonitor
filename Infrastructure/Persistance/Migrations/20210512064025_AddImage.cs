using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistance.Migrations
{
    public partial class AddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Patitents");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Patitents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Patitents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Patitents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PatientImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientImage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patitents_ImageId",
                table: "Patitents",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patitents_PatientImage_ImageId",
                table: "Patitents",
                column: "ImageId",
                principalTable: "PatientImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patitents_PatientImage_ImageId",
                table: "Patitents");

            migrationBuilder.DropTable(
                name: "PatientImage");

            migrationBuilder.DropIndex(
                name: "IX_Patitents_ImageId",
                table: "Patitents");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Patitents");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Patitents");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Patitents");

            migrationBuilder.AddColumn<float>(
                name: "Temperature",
                table: "Patitents",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
