using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Tenant_TenantId",
                table: "Wallet");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletItem_Wallet_WalletId",
                table: "WalletItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletItem",
                table: "WalletItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant");

            migrationBuilder.RenameTable(
                name: "WalletItem",
                newName: "WalletItems");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "Wallets");

            migrationBuilder.RenameTable(
                name: "Tenant",
                newName: "Tenants");

            migrationBuilder.RenameIndex(
                name: "IX_WalletItem_WalletId",
                table: "WalletItems",
                newName: "IX_WalletItems_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_TenantId",
                table: "Wallets",
                newName: "IX_Wallets_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_Email",
                table: "Tenants",
                newName: "IX_Tenants_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletItems",
                table: "WalletItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletItems_Wallets_WalletId",
                table: "WalletItems",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Tenants_TenantId",
                table: "Wallets",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletItems_Wallets_WalletId",
                table: "WalletItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Tenants_TenantId",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletItems",
                table: "WalletItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "Wallet");

            migrationBuilder.RenameTable(
                name: "WalletItems",
                newName: "WalletItem");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Tenant");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_TenantId",
                table: "Wallet",
                newName: "IX_Wallet_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_WalletItems_WalletId",
                table: "WalletItem",
                newName: "IX_WalletItem_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_Email",
                table: "Tenant",
                newName: "IX_Tenant_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletItem",
                table: "WalletItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Tenant_TenantId",
                table: "Wallet",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WalletItem_Wallet_WalletId",
                table: "WalletItem",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
