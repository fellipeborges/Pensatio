using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensatiu.Repository.Migrations
{
    public partial class dataannotations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DiaCobranca",
                table: "Pacientes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Pacientes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicioTratamento",
                table: "Pacientes",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DiaCobranca",
                table: "Pacientes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Pacientes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicioTratamento",
                table: "Pacientes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
