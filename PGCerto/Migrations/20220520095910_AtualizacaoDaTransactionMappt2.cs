using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AtualizacaoDaTransactionMappt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Transactions_NSU",
                table: "Installment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameColumn(
                name: "NetValue",
                table: "Transaction",
                newName: "ValorLiquido");

            migrationBuilder.RenameColumn(
                name: "InstallmentsNumber",
                table: "Transaction",
                newName: "NumeroParcelas");

            migrationBuilder.RenameColumn(
                name: "FixedRate",
                table: "Transaction",
                newName: "TaxaFixa");

            migrationBuilder.RenameColumn(
                name: "Disapproval",
                table: "Transaction",
                newName: "DataReprovacao");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transaction",
                newName: "DataTransacao");

            migrationBuilder.RenameColumn(
                name: "CreditCardLastNumbers",
                table: "Transaction",
                newName: "UltimosDigitosCartao");

            migrationBuilder.RenameColumn(
                name: "BruteValue",
                table: "Transaction",
                newName: "ValorBruto");

            migrationBuilder.RenameColumn(
                name: "Approval",
                table: "Transaction",
                newName: "DataAprovacao");

            migrationBuilder.RenameColumn(
                name: "Anticipation",
                table: "Transaction",
                newName: "Antecipado");

            migrationBuilder.RenameColumn(
                name: "AcquirerConfirmation",
                table: "Transaction",
                newName: "ConfirmacaoAdquirinte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "NSU");

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Transaction_NSU",
                table: "Installment",
                column: "NSU",
                principalTable: "Transaction",
                principalColumn: "NSU",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installment_Transaction_NSU",
                table: "Installment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ValorLiquido",
                table: "Transactions",
                newName: "NetValue");

            migrationBuilder.RenameColumn(
                name: "ValorBruto",
                table: "Transactions",
                newName: "BruteValue");

            migrationBuilder.RenameColumn(
                name: "UltimosDigitosCartao",
                table: "Transactions",
                newName: "CreditCardLastNumbers");

            migrationBuilder.RenameColumn(
                name: "TaxaFixa",
                table: "Transactions",
                newName: "FixedRate");

            migrationBuilder.RenameColumn(
                name: "NumeroParcelas",
                table: "Transactions",
                newName: "InstallmentsNumber");

            migrationBuilder.RenameColumn(
                name: "DataTransacao",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DataReprovacao",
                table: "Transactions",
                newName: "Disapproval");

            migrationBuilder.RenameColumn(
                name: "DataAprovacao",
                table: "Transactions",
                newName: "Approval");

            migrationBuilder.RenameColumn(
                name: "ConfirmacaoAdquirinte",
                table: "Transactions",
                newName: "AcquirerConfirmation");

            migrationBuilder.RenameColumn(
                name: "Antecipado",
                table: "Transactions",
                newName: "Anticipation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "NSU");

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_Transactions_NSU",
                table: "Installment",
                column: "NSU",
                principalTable: "Transactions",
                principalColumn: "NSU",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
