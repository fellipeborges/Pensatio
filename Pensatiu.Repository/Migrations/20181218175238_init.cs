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
                    Nome2 = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(maxLength: 7, nullable: false),
                    Endereco = table.Column<string>(maxLength: 150, nullable: true),
                    CEP = table.Column<string>(maxLength: 8, nullable: true),
                    Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    UF = table.Column<string>(maxLength: 2, nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    ValorCustoMensal = table.Column<double>(nullable: true),
                    ValorAluguelMensal = table.Column<double>(nullable: true),
                    ValorLocacaoHora = table.Column<double>(nullable: true),
                    ValorLocomocao = table.Column<double>(nullable: true)
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
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Telefone = table.Column<string>(maxLength: 20, nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    DataInicioTratamento = table.Column<DateTime>(nullable: true),
                    TipoCobranca = table.Column<int>(nullable: false),
                    ValorCobranca = table.Column<double>(nullable: false),
                    DiaCobranca = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PacienteConsultasRecorrentes",
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
                    table.PrimaryKey("PK_PacienteConsultasRecorrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteConsultasRecorrentes_Consultorios_ConsultorioId",
                        column: x => x.ConsultorioId,
                        principalTable: "Consultorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteConsultasRecorrentes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacienteConsultasRecorrentes_ConsultorioId",
                table: "PacienteConsultasRecorrentes",
                column: "ConsultorioId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteConsultasRecorrentes_PacienteId",
                table: "PacienteConsultasRecorrentes",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacienteConsultasRecorrentes");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
