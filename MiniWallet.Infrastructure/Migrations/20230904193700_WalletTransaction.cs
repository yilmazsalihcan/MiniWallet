using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniWallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WalletTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("638fe4b5-acd6-43fa-8eaa-a240c452f145"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b035416f-079f-48f2-be95-10ac5cde43e6"));

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("a71a0516-097e-48f9-8131-5ef1ffd1c751"), "Salih Can", "YILMAZ" },
                    { new Guid("e13c373a-a88f-4e52-8a4c-b1d8e0a6d640"), "RoofStacks", "Company" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletTransactions");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a71a0516-097e-48f9-8131-5ef1ffd1c751"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e13c373a-a88f-4e52-8a4c-b1d8e0a6d640"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("638fe4b5-acd6-43fa-8eaa-a240c452f145"), "RoofStacks", "Company" },
                    { new Guid("b035416f-079f-48f2-be95-10ac5cde43e6"), "Salih Can", "YILMAZ" }
                });
        }
    }
}
