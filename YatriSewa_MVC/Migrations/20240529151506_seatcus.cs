using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YatriSewa_MVC.Migrations
{
    /// <inheritdoc />
    public partial class seatcus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Customers_CustomerId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_CustomerId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Passengers");

            migrationBuilder.AddColumn<int>(
                name: "PassengerId",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_PassengerId",
                table: "Seats",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Passengers_PassengerId",
                table: "Seats",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "PassengerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Passengers_PassengerId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_PassengerId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_CustomerId",
                table: "Passengers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Customers_CustomerId",
                table: "Passengers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "customer_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
