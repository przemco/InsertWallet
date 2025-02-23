using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Cantor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rate_CurrencyTable_CurrencyTablId",
                table: "Rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rate",
                table: "Rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyTable",
                table: "CurrencyTable");

            migrationBuilder.RenameTable(
                name: "Rate",
                newName: "Rates");

            migrationBuilder.RenameTable(
                name: "CurrencyTable",
                newName: "CurrencyTables");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_CurrencyTablId",
                table: "Rates",
                newName: "IX_Rates_CurrencyTablId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rates",
                table: "Rates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyTables",
                table: "CurrencyTables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_CurrencyTables_CurrencyTablId",
                table: "Rates",
                column: "CurrencyTablId",
                principalTable: "CurrencyTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_CurrencyTables_CurrencyTablId",
                table: "Rates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rates",
                table: "Rates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyTables",
                table: "CurrencyTables");

            migrationBuilder.RenameTable(
                name: "Rates",
                newName: "Rate");

            migrationBuilder.RenameTable(
                name: "CurrencyTables",
                newName: "CurrencyTable");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_CurrencyTablId",
                table: "Rate",
                newName: "IX_Rate_CurrencyTablId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rate",
                table: "Rate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyTable",
                table: "CurrencyTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_CurrencyTable_CurrencyTablId",
                table: "Rate",
                column: "CurrencyTablId",
                principalTable: "CurrencyTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
