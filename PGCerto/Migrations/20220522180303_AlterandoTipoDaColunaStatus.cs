using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AlterandoTipoDaColunaStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Transaction_NSU",
                table: "Installment");

            migrationBuilder.RenameColumn(
                name: "NSU",
                table: "Installment",
                newName: "Nsu");

            migrationBuilder.RenameIndex(
                name: "IX_Installment_NSU",
                table: "Installment",
                newName: "IX_Installment_Nsu");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AnticipationTransaction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Transaction_Nsu",
                table: "Installment",
                column: "Nsu",
                principalTable: "Transaction",
                principalColumn: "Nsu",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Transaction_Nsu",
                table: "Installment");

            migrationBuilder.RenameColumn(
                name: "Nsu",
                table: "Installment",
                newName: "NSU");

            migrationBuilder.RenameIndex(
                name: "IX_Installment_Nsu",
                table: "Installment",
                newName: "IX_Installment_NSU");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AnticipationTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Transaction_NSU",
                table: "Installment",
                column: "NSU",
                principalTable: "Transaction",
                principalColumn: "Nsu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
