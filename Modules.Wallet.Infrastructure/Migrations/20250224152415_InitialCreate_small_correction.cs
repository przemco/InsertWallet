using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_small_correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Voulume_CurrencyName",
                table: "WalletItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Voulume_CurrencyName",
                table: "WalletItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
