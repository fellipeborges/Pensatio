﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pensatiu.Repository.Context;

namespace Pensatiu.Repository.Migrations
{
    [DbContext(typeof(PensatiuDbContext))]
    [Migration("20181130231958_dataannotations2")]
    partial class dataannotations2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pensatiu.Entities.ConsultaRecorrente", b =>
                {
                    b.Property<int>("PacienteId");

                    b.Property<int>("ConsultorioId");

                    b.Property<int>("DiaSemana");

                    b.Property<TimeSpan>("Hora");

                    b.HasKey("PacienteId", "ConsultorioId");

                    b.HasIndex("ConsultorioId");

                    b.ToTable("ConsultasRecorrentes");
                });

            modelBuilder.Entity("Pensatiu.Entities.Consultorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .HasMaxLength(8);

                    b.Property<string>("Cidade")
                        .HasMaxLength(100);

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.Property<string>("Endereco")
                        .HasMaxLength(150);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Tipo");

                    b.Property<string>("UF")
                        .HasMaxLength(2);

                    b.Property<double>("ValorAluguelMensal");

                    b.Property<double>("ValorCustoMensal");

                    b.Property<double>("ValorLocacaoHora");

                    b.Property<double>("ValorLocomocao");

                    b.HasKey("Id");

                    b.ToTable("Consultorios");
                });

            modelBuilder.Entity("Pensatiu.Entities.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataInicioTratamento");

                    b.Property<DateTime?>("DataNascimento");

                    b.Property<int?>("DiaCobranca");

                    b.Property<int>("Genero");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .HasMaxLength(20);

                    b.Property<int>("TipoCobranca");

                    b.Property<double>("ValorCobranca");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Pensatiu.Entities.ConsultaRecorrente", b =>
                {
                    b.HasOne("Pensatiu.Entities.Consultorio", "Consultorio")
                        .WithMany()
                        .HasForeignKey("ConsultorioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pensatiu.Entities.Paciente", "Paciente")
                        .WithMany("ConsultasRecorrentes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}