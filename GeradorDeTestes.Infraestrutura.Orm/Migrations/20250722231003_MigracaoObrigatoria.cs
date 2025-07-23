using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorDeTestes.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoObrigatoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Materias",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Questoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Enunciado = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MateriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Finalizado = table.Column<bool>(type: "boolean", nullable: false),
                    DataCriacao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questoes_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Testes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DisciplinaId = table.Column<Guid>(type: "uuid", nullable: false),
                    MateriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Serie = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeQuestoes = table.Column<int>(type: "integer", nullable: false),
                    Recuperacao = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testes_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Testes_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alternativas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    QuestaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Correta = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternativas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alternativas_Questoes_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestaoTeste",
                columns: table => new
                {
                    QuestoesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoTeste", x => new { x.QuestoesId, x.TestesId });
                    table.ForeignKey(
                        name: "FK_QuestaoTeste_Questoes_QuestoesId",
                        column: x => x.QuestoesId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestaoTeste_Testes_TestesId",
                        column: x => x.TestesId,
                        principalTable: "Testes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternativas_QuestaoId",
                table: "Alternativas",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoTeste_TestesId",
                table: "QuestaoTeste",
                column: "TestesId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_MateriaId",
                table: "Questoes",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Testes_DisciplinaId",
                table: "Testes",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Testes_MateriaId",
                table: "Testes",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alternativas");

            migrationBuilder.DropTable(
                name: "QuestaoTeste");

            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "Testes");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Materias",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
