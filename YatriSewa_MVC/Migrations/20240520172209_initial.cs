using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YatriSewa_MVC.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Drivers_driver_ID",
                table: "Buses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_UserLogin_login_ID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_customer_ID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionReports_Reservations_ReservationId",
                table: "TransactionReports");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_TransactionReports_ReservationId",
                table: "TransactionReports");

            migrationBuilder.DropIndex(
                name: "IX_Payments_customer_ID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Customers_login_ID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Buses_driver_ID",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "TransactionReports");

            migrationBuilder.RenameColumn(
                name: "bus_number",
                table: "Buses",
                newName: "bus_no");

            migrationBuilder.RenameColumn(
                name: "bus_ID",
                table: "Buses",
                newName: "BusId");

            migrationBuilder.RenameColumn(
                name: "driver_ID",
                table: "Buses",
                newName: "seat_capacity");

            migrationBuilder.RenameColumn(
                name: "bus_status",
                table: "Buses",
                newName: "to_location");

            migrationBuilder.RenameColumn(
                name: "bus_seats",
                table: "Buses",
                newName: "price");

            migrationBuilder.AlterColumn<string>(
                name: "bus_no",
                table: "Buses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "bus_name",
                table: "Buses",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Buses",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "from_location",
                table: "Buses",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "photo_path",
                table: "Buses",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    OperatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operator_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    contact_no = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    license_no = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    issue_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.OperatorId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wifi = table.Column<bool>(type: "bit", nullable: false),
                    ac = table.Column<bool>(type: "bit", nullable: false),
                    dinner_lunch = table.Column<bool>(type: "bit", nullable: false),
                    safety_features = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    essentials = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    snacks = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_OperatorId",
                table: "Buses",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BusId",
                table: "Services",
                column: "BusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Operators_OperatorId",
                table: "Buses",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Operators_OperatorId",
                table: "Buses");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Buses_OperatorId",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "bus_name",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "from_location",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "photo_path",
                table: "Buses");

            migrationBuilder.RenameColumn(
                name: "bus_no",
                table: "Buses",
                newName: "bus_number");

            migrationBuilder.RenameColumn(
                name: "BusId",
                table: "Buses",
                newName: "bus_ID");

            migrationBuilder.RenameColumn(
                name: "to_location",
                table: "Buses",
                newName: "bus_status");

            migrationBuilder.RenameColumn(
                name: "seat_capacity",
                table: "Buses",
                newName: "driver_ID");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Buses",
                newName: "bus_seats");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "TransactionReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "bus_number",
                table: "Buses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    driver_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bus_ID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.driver_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports_ReservationId",
                table: "TransactionReports",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_customer_ID",
                table: "Payments",
                column: "customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_login_ID",
                table: "Customers",
                column: "login_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_driver_ID",
                table: "Buses",
                column: "driver_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Drivers_driver_ID",
                table: "Buses",
                column: "driver_ID",
                principalTable: "Drivers",
                principalColumn: "driver_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_UserLogin_login_ID",
                table: "Customers",
                column: "login_ID",
                principalTable: "UserLogin",
                principalColumn: "login_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_customer_ID",
                table: "Payments",
                column: "customer_ID",
                principalTable: "Customers",
                principalColumn: "customer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionReports_Reservations_ReservationId",
                table: "TransactionReports",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "reservation_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
