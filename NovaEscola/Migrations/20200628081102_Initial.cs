using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NovaEscola.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ativo = table.Column<bool>(nullable: false, defaultValueSql: "TRUE"),
                    DataInclusao = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_DATE"),
                    DataModificacao = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_DATE"),
                    Cep = table.Column<int>(maxLength: 8, nullable: false),
                    Lougradouro = table.Column<string>(maxLength: 255, nullable: false),
                    Numero = table.Column<string>(maxLength: 6, nullable: false),
                    Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(maxLength: 255, nullable: false),
                    Uf = table.Column<string>(maxLength: 2, nullable: false),
                    Pais = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    TelFixo = table.Column<string>(nullable: false),
                    TelMovel = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: true),
                    DataFundacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Ensino = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ativo = table.Column<bool>(nullable: false, defaultValueSql: "TRUE"),
                    DataInclusao = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_DATE"),
                    DataModificacao = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_DATE"),
                    Turno = table.Column<int>(nullable: false),
                    NomeTurma = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    QuantidadeVagas = table.Column<int>(nullable: false),
                    SerieId = table.Column<int>(nullable: false),
                    EscolaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Escolas",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "Complemento", "DataFundacao", "Descricao", "Email", "Lougradouro", "Name", "Numero", "Pais", "TelFixo", "TelMovel", "Uf" },
                values: new object[,]
                {
                    { 1, "Tijuca", 20540030, "Rio de Janeiro", "Apto 201 F", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escola Municipal ABC", "contato@escolaabc.com.br", "Rua Severino Brandão", "Escola ABC", "41", "Brasil", "2125692407", "21995132912", "RJ" },
                    { 2, "Tijuca", 20540030, "Rio de Janeiro", "Apto 301", new DateTime(1981, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escola Municipal DEF", "contato@escoladef.com.br", "Rua Barão de Mesquita", "Escola DEF", "134", "Brasil", "2125692407", "21995132912", "RJ" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Ensino", "Nome" },
                values: new object[,]
                {
                    { 1, 1, "1º ano" },
                    { 2, 1, "2º ano" },
                    { 3, 1, "3º ano" },
                    { 4, 1, "4º ano" },
                    { 5, 1, "5º ano" },
                    { 6, 1, "6º ano" },
                    { 7, 1, "7º ano" },
                    { 8, 1, "8º ano" },
                    { 9, 1, "9º ano" },
                    { 10, 2, "1º ano" },
                    { 11, 2, "2º ano" },
                    { 12, 2, "3º ano" }
                });

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Id", "Descricao", "EscolaId", "NomeTurma", "QuantidadeVagas", "SerieId", "Turno" },
                values: new object[,]
                {
                    { 1, "Turma 101", 1, "101", 30, 1, 1 },
                    { 2, "Turma 201", 1, "201", 30, 2, 1 },
                    { 3, "Turma 301", 1, "301", 30, 3, 1 },
                    { 4, "Turma 401", 1, "401", 30, 4, 1 },
                    { 5, "Turma 501", 1, "501", 30, 5, 1 },
                    { 6, "Turma 601", 1, "601", 30, 6, 1 },
                    { 7, "Turma 701", 1, "701", 30, 7, 1 },
                    { 8, "Turma 801", 1, "801", 30, 8, 1 },
                    { 9, "Turma 901", 1, "901", 30, 9, 1 },
                    { 10, "Turma 1001", 1, "1001", 35, 10, 2 },
                    { 11, "Turma 1002", 1, "1002", 35, 10, 2 },
                    { 12, "Turma 2001", 1, "2001", 35, 11, 2 },
                    { 13, "Turma 2002", 1, "2002", 35, 11, 2 },
                    { 14, "Turma 3001", 1, "3001", 35, 11, 2 },
                    { 15, "Turma 3002", 1, "3002", 35, 11, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EscolaId",
                table: "Turmas",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_SerieId",
                table: "Turmas",
                column: "SerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Escolas");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
