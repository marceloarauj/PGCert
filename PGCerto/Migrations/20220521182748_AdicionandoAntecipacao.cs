using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AdicionandoAntecipacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anticipation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicioAnalise = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFimAnalise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ValorSolicitado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorAntecipado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anticipation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnticipationTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnticipationId = table.Column<int>(type: "int", nullable: false),
                    TransactionNsu = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnticipationTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnticipationTransaction_Anticipation_AnticipationId",
                        column: x => x.AnticipationId,
                        principalTable: "Anticipation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnticipationTransaction_AnticipationId",
                table: "AnticipationTransaction",
                column: "AnticipationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnticipationTransaction");

            migrationBuilder.DropTable(
                name: "Anticipation");
        }
    }
}
