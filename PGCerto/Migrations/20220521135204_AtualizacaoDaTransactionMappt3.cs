using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AtualizacaoDaTransactionMappt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Receivement",
                table: "Installment",
                newName: "DataRecebimento");

            migrationBuilder.RenameColumn(
                name: "PassedOn",
                table: "Installment",
                newName: "DataRepasse");

            migrationBuilder.RenameColumn(
                name: "NetValue",
                table: "Installment",
                newName: "ValorLiquido");

            migrationBuilder.RenameColumn(
                name: "InstallmentNumber",
                table: "Installment",
                newName: "NumeroParcela");

            migrationBuilder.RenameColumn(
                name: "BruteValue",
                table: "Installment",
                newName: "ValorBruto");

            migrationBuilder.RenameColumn(
                name: "AntecipatedValue",
                table: "Installment",
                newName: "ValorAntecipado");

            migrationBuilder.AlterColumn<string>(
                name: "UltimosDigitosCartao",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataReprovacao",
                table: "Transaction",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorLiquido",
                table: "Installment",
                newName: "NetValue");

            migrationBuilder.RenameColumn(
                name: "ValorBruto",
                table: "Installment",
                newName: "BruteValue");

            migrationBuilder.RenameColumn(
                name: "ValorAntecipado",
                table: "Installment",
                newName: "AntecipatedValue");

            migrationBuilder.RenameColumn(
                name: "NumeroParcela",
                table: "Installment",
                newName: "InstallmentNumber");

            migrationBuilder.RenameColumn(
                name: "DataRepasse",
                table: "Installment",
                newName: "PassedOn");

            migrationBuilder.RenameColumn(
                name: "DataRecebimento",
                table: "Installment",
                newName: "Receivement");

            migrationBuilder.AlterColumn<string>(
                name: "UltimosDigitosCartao",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataReprovacao",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
