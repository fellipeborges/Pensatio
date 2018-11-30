using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensatiu.Repository.Migrations
{
    public partial class Join : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultasRecorrentes",
                table: "ConsultasRecorrentes");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasRecorrentes_PacienteId",
                table: "ConsultasRecorrentes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ConsultasRecorrentes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultasRecorrentes",
                table: "ConsultasRecorrentes",
                columns: new[] { "PacienteId", "ConsultorioId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultasRecorrentes",
                table: "ConsultasRecorrentes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ConsultasRecorrentes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultasRecorrentes",
                table: "ConsultasRecorrentes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasRecorrentes_PacienteId",
                table: "ConsultasRecorrentes",
                column: "PacienteId");
        }
    }
}
