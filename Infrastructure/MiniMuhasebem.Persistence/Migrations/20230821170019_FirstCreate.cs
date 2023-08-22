using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniMuhasebem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_NAME = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    PHONE = table.Column<string>(type: "nchar(13)", nullable: false),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GENDER = table.Column<int>(type: "int", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INCOMES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CASH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREDIT_CARD1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREDIT_CARD2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TOTAL_INCOME = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCOMES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WHOLESALERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHOLESALER_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHOLESALERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LAST_LOGIN_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_LOGIN_IP = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ROLE_ID = table.Column<int>(type: "int", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_IMAGES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    PATH = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_IMAGES", x => x.ID);
                    table.ForeignKey(
                        name: "CUSTOMER_IMAGE_CUSTUMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DEBTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHOLESALER_ID = table.Column<int>(type: "int", nullable: true),
                    ORDER_DEBT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_DEBT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEBTS", x => x.ID);
                    table.ForeignKey(
                        name: "DEBT_WHOLESALER_WHOLESALER_ID",
                        column: x => x.WHOLESALER_ID,
                        principalTable: "WHOLESALERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHOLESALER_ID = table.Column<int>(type: "int", nullable: true),
                    ORDER_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_ORDER_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ID);
                    table.ForeignKey(
                        name: "ORDER_WHOLESALER_WHOLESALER_ID",
                        column: x => x.WHOLESALER_ID,
                        principalTable: "WHOLESALERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHOLESALER_ID = table.Column<int>(type: "int", nullable: true),
                    ORDER_PAYMENT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_PAYMENT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PAYMENT_TYPE = table.Column<int>(type: "int", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "PEYMENT_WHOLESALER_WHOLESALER_ID",
                        column: x => x.WHOLESALER_ID,
                        principalTable: "WHOLESALERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MONTHS_END",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RAPOR_OLUSTUR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INCOME_ID = table.Column<int>(type: "int", nullable: false),
                    TOTAL_INCOME = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    TOTAL_ORDER_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PAYMENT_ID = table.Column<int>(type: "int", nullable: false),
                    TOTAL_PAYMENT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DEBT_ID = table.Column<int>(type: "int", nullable: false),
                    TOTAL_DEBT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MONTH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TRANSFER_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MONTHS_END", x => x.ID);
                    table.ForeignKey(
                        name: "MONTHENDS_DEBT_DEBT_ID",
                        column: x => x.DEBT_ID,
                        principalTable: "DEBTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "MONTHENDS_INCOME_INCOME_ID",
                        column: x => x.INCOME_ID,
                        principalTable: "INCOMES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "MONTHENDS_ORDER_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDERS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "MONTHENDS_PAYMENT_PAYMENT_ID",
                        column: x => x.PAYMENT_ID,
                        principalTable: "PAYMENTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_CUSTOMER_ID",
                table: "ACCOUNTS",
                column: "CUSTOMER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_IMAGES_CUSTOMER_ID",
                table: "CUSTOMER_IMAGES",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEBTS_WHOLESALER_ID",
                table: "DEBTS",
                column: "WHOLESALER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MONTHS_END_DEBT_ID",
                table: "MONTHS_END",
                column: "DEBT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MONTHS_END_INCOME_ID",
                table: "MONTHS_END",
                column: "INCOME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MONTHS_END_ORDER_ID",
                table: "MONTHS_END",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MONTHS_END_PAYMENT_ID",
                table: "MONTHS_END",
                column: "PAYMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_WHOLESALER_ID",
                table: "ORDERS",
                column: "WHOLESALER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_WHOLESALER_ID",
                table: "PAYMENTS",
                column: "WHOLESALER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "CUSTOMER_IMAGES");

            migrationBuilder.DropTable(
                name: "MONTHS_END");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "DEBTS");

            migrationBuilder.DropTable(
                name: "INCOMES");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "WHOLESALERS");
        }
    }
}
