using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    NSU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approval = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disapproval = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anticipation = table.Column<bool>(type: "bit", nullable: false),
                    BruteValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Installments = table.Column<int>(type: "int", nullable: false),
                    CreditCardLastNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.NSU);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
