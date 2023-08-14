using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdaSigortaAppYeniWebApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdaSigortaAppMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KimlikNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Dask",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Il = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    TanzimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VadeBaslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VadeBitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prim = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dask", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_Dask_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Dask_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Trafik",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlakaIlKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlakaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    TanzimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VadeBaslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VadeBitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prim = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trafik", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_Trafik_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Trafik_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dask_PersonId",
                table: "Dask",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Dask_ProductId",
                table: "Dask",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Trafik_PersonId",
                table: "Trafik",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Trafik_ProductId",
                table: "Trafik",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dask");

            migrationBuilder.DropTable(
                name: "Trafik");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
