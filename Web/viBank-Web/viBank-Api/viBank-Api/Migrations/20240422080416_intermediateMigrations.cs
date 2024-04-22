using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace viBank_Api.Migrations
{
    /// <inheritdoc />
    public partial class intermediateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ATMID",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "ATMsID",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ATMsID",
                table: "Transactions",
                column: "ATMsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ATMs_ATMsID",
                table: "Transactions",
                column: "ATMsID",
                principalTable: "ATMs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ATMs_ATMsID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ATMsID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ATMID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ATMsID",
                table: "Transactions");
        }
    }
}
