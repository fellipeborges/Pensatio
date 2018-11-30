using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensatiu.Repository.Migrations
{
    public partial class dataannotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Pacientes",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Pacientes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pacientes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Consultorios",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Consultorios",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Consultorios",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Pacientes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Pacientes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pacientes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Consultorios",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Consultorios",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Consultorios",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
