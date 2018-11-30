using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensatiu.Repository.Migrations
{
    public partial class da1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorLocomocao",
                table: "Consultorios",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "ValorLocacaoHora",
                table: "Consultorios",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "ValorCustoMensal",
                table: "Consultorios",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "ValorAluguelMensal",
                table: "Consultorios",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorLocomocao",
                table: "Consultorios",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ValorLocacaoHora",
                table: "Consultorios",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ValorCustoMensal",
                table: "Consultorios",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ValorAluguelMensal",
                table: "Consultorios",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
