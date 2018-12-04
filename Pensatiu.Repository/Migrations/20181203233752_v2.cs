using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensatiu.Repository.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultasRecorrentes");

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

            migrationBuilder.CreateTable(
                name: "ConsultasRecorrentes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false),
                    ConsultorioId = table.Column<int>(nullable: false),
                    DiaSemana = table.Column<int>(nullable: false),
                    Hora = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasRecorrentes", x => new { x.PacienteId, x.ConsultorioId });
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
        }
    }
}
