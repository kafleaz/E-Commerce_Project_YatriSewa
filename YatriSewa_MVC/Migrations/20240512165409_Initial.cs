using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YatriSewa_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    driver_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    bus_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.driver_ID);
                });

            migrationBuilder.CreateTable(
                name: "Login_Detail",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_Detail", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    bus_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bus_number = table.Column<int>(type: "int", nullable: false),
                    bus_status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    bus_seats = table.Column<int>(type: "int", nullable: false),
                    driver_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.bus_ID);
                    table.ForeignKey(
                        name: "FK_Bus_Drivers_driver_ID",
                        column: x => x.driver_ID,
                        principalTable: "Drivers",
                        principalColumn: "driver_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login_ID = table.Column<int>(type: "int", nullable: false),
                    LoginUserLoginId = table.Column<int>(type: "int", nullable: false),
                    fname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    contact_add = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customer_ID);
                    table.ForeignKey(
                        name: "FK_Customer_Login_Detail_LoginUserLoginId",
                        column: x => x.LoginUserLoginId,
                        principalTable: "Login_Detail",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    order_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_ID = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.order_ID);
                    table.ForeignKey(
                        name: "FK_Order_Customer_customer_ID",
                        column: x => x.customer_ID,
                        principalTable: "Customer",
                        principalColumn: "customer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    reservation_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_ID = table.Column<int>(type: "int", nullable: false),
                    bus_ID = table.Column<int>(type: "int", nullable: false),
                    departure_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    reservation_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.reservation_ID);
                    table.ForeignKey(
                        name: "FK_Reservation_Customer_customer_ID",
                        column: x => x.customer_ID,
                        principalTable: "Customer",
                        principalColumn: "customer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    payment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_ID = table.Column<int>(type: "int", nullable: false),
                    reservation_ID = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.payment_ID);
                    table.ForeignKey(
                        name: "FK_Payment_Customer_customer_ID",
                        column: x => x.customer_ID,
                        principalTable: "Customer",
                        principalColumn: "customer_ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Payment_Reservation_reservation_ID",
                        column: x => x.reservation_ID,
                        principalTable: "Reservation",
                        principalColumn: "reservation_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionReport",
                columns: table => new
                {
                    report_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_ID = table.Column<int>(type: "int", nullable: false),
                    reservation_ID = table.Column<int>(type: "int", nullable: false),
                    payment_ID = table.Column<int>(type: "int", nullable: false),
                    report_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionReport", x => x.report_ID);
                    table.ForeignKey(
                        name: "FK_TransactionReport_Customer_customer_ID",
                        column: x => x.customer_ID,
                        principalTable: "Customer",
                        principalColumn: "customer_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionReport_Payment_payment_ID",
                        column: x => x.payment_ID,
                        principalTable: "Payment",
                        principalColumn: "payment_ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TransactionReport_Reservation_reservation_ID",
                        column: x => x.reservation_ID,
                        principalTable: "Reservation",
                        principalColumn: "reservation_ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_driver_ID",
                table: "Bus",
                column: "driver_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_LoginUserLoginId",
                table: "Customer",
                column: "LoginUserLoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_customer_ID",
                table: "Order",
                column: "customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_customer_ID",
                table: "Payment",
                column: "customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_reservation_ID",
                table: "Payment",
                column: "reservation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_customer_ID",
                table: "Reservation",
                column: "customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReport_customer_ID",
                table: "TransactionReport",
                column: "customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReport_payment_ID",
                table: "TransactionReport",
                column: "payment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReport_reservation_ID",
                table: "TransactionReport",
                column: "reservation_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "TransactionReport");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Login_Detail");
        }
    }
}
