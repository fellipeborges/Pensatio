using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensatiu.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cor = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(maxLength: 150, nullable: true),
                    CEP = table.Column<string>(maxLength: 8, nullable: true),
                    Cidade = table.Column<string>(maxLength: 8, nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    ValorCustoMensal = table.Column<double>(nullable: false),
                    ValorAluguelMensal = table.Column<double>(nullable: false),
                    ValorLocacaoHora = table.Column<double>(nullable: false),
                    ValorLocomocao = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    DataInicioTratamento = table.Column<DateTime>(nullable: false),
                    TipoCobranca = table.Column<int>(nullable: false),
                    ValorCobranca = table.Column<double>(nullable: false),
                    DiaCobranca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasRecorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(nullable: false),
                    ConsultorioId = table.Column<int>(nullable: false),
                    DiaSemana = table.Column<int>(nullable: false),
                    Hora = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasRecorrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultasRecorrentes_Consultorios_ConsultorioId",
                        column: x => x.ConsultorioId,
                        principalTable: "Consultorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultasRecorrentes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasRecorrentes_ConsultorioId",
                table: "ConsultasRecorrentes",
                column: "ConsultorioId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasRecorrentes_PacienteId",
                table: "ConsultasRecorrentes",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultasRecorrentes");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
