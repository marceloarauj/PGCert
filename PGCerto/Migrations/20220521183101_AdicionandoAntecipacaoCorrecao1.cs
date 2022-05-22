using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AdicionandoAntecipacaoCorrecao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnticipationTransaction_Anticipation_AnticipationId",
                table: "AnticipationTransaction");

            migrationBuilder.RenameColumn(
                name: "TransactionNsu",
                table: "AnticipationTransaction",
                newName: "Nsu");

            migrationBuilder.RenameColumn(
                name: "AnticipationId",
                table: "AnticipationTransaction",
                newName: "AntecipacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_AnticipationTransaction_AnticipationId",
                table: "AnticipationTransaction",
                newName: "IX_AnticipationTransaction_AntecipacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnticipationTransaction_Anticipation_AntecipacaoId",
                table: "AnticipationTransaction",
                column: "AntecipacaoId",
                principalTable: "Anticipation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnticipationTransaction_Anticipation_AntecipacaoId",
                table: "AnticipationTransaction");

            migrationBuilder.RenameColumn(
                name: "Nsu",
                table: "AnticipationTransaction",
                newName: "TransactionNsu");

            migrationBuilder.RenameColumn(
                name: "AntecipacaoId",
                table: "AnticipationTransaction",
                newName: "AnticipationId");

            migrationBuilder.RenameIndex(
                name: "IX_AnticipationTransaction_AntecipacaoId",
                table: "AnticipationTransaction",
                newName: "IX_AnticipationTransaction_AnticipationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnticipationTransaction_Anticipation_AnticipationId",
                table: "AnticipationTransaction",
                column: "AnticipationId",
                principalTable: "Anticipation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
