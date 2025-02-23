using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WalletId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Voulume_Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Voulume_CurrencyCode = table.Column<string>(type: "TEXT", nullable: false),
                    Voulume_CurrencyName = table.Column<string>(type: "TEXT", nullable: false),
                    Voulume_CurrencySign = table.Column<char>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletItem_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_Email",
                table: "Tenant",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_TenantId",
                table: "Wallet",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletItem_WalletId",
                table: "WalletItem",
                column: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletItem");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
