using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI3110MKLab2CRRUD.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    WeightInPounds = table.Column<double>(type: "REAL", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    ImageMIMEType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "ImageData", "ImageMIMEType", "InStock", "ManufactureDate", "Price", "WeightInPounds" },
                values: new object[] { 1, null, "PNG", true, new DateTime(2026, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 21.99m, 1.1000000000000001 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
