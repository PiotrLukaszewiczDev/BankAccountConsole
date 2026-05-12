using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddBalanceAfterToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BalanceAfter",
                table: "TransactionEntities",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceAfter",
                table: "TransactionEntities");
        }
    }
}
