using Microsoft.Extensions.DependencyInjection;
using Pensatiu.Entities;
using Pensatiu.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pensatiu.Test.Util
{
    static class InMemoryDbContextHelper
    {
        private static ServiceProvider _serviceProvider;
        private static PensatiuDbContext _dbContext;

        public static PensatiuDbContext GetInMemoryDbContext()
        {
            if (_serviceProvider == null)
            {
                _serviceProvider = ServiceProviderHelper.GetServiceProvider();
            }
            if (_dbContext == null)
            {
                _dbContext = _serviceProvider.GetService<PensatiuDbContext>();
                LoadData_Consultorios();
                LoadData_Pacientes();
            }

            return _dbContext;
        }

        private static void LoadData_Consultorios()
        {
            var items = new List<Consultorio>
            {
                new Consultorio { Nome = "Tatuapé", Cor = "#990000", Endereco = "Rua Tuiuti, 645, 6o Andar, Cj 65, Tatuapé", CEP = "03178200", Cidade = "São Paulo", UF = "SP", Tipo = TipoConsultorioEnum.Proprio, ValorCustoMensal = 1000.00F, ValorLocomocao = 12.00 },
                new Consultorio { Nome = "Mooca", Cor = "#006600", Endereco = "Rua Cassandoca, 125, Mooca", CEP = "03169010", Cidade = "São Paulo", UF = "SP", Tipo = TipoConsultorioEnum.AluguelMensal, ValorAluguelMensal = 1500.00F, ValorLocomocao = 10.00 },
                new Consultorio { Nome = "Bela Cintra", Cor = "#000066", Endereco = "Rua Bela Cintra, 768, Consolação", CEP = "01415002", Cidade = "São Paulo", UF = "SP", Tipo = TipoConsultorioEnum.LocacaoPorHora, ValorLocacaoHora = 80.00F, ValorLocomocao = 15.00 }
            };
            _dbContext.Consultorios.AddRange(items);
            _dbContext.SaveChanges();
        }

        private static void LoadData_Pacientes()
        {
            var items = new List<Paciente>
            {
                new Paciente
                {
                    Id = 1,
                    Nome = "João",
                    Sobrenome = "da Silva",
                    DataInicioTratamento = new DateTime(2018,1,1),
                    DataNascimento = new DateTime(1986, 12, 5),
                    Genero = PacienteGeneroEnum.Masculino,
                    Telefone = "11 984840922",
                    TipoCobranca = PacienteTipoCobrancaEnum.Mensal,
                    ValorCobranca = 500.00,
                    DiaCobranca = 20,
                    PacienteConsultasRecorrentes = new List<PacienteConsultaRecorrente>
                    {
                        new PacienteConsultaRecorrente{
                            Id = 1,
                            PacienteId = 1,
                            Hora = new TimeSpan(14, 30, 0),
                            DiaSemana = PacienteConsultaRecorrenteDiaDaSemanaEnum.QuartaFeira,
                            ConsultorioId = 1,
                            Consultorio = new Consultorio{Id = 1, Nome = "Tatuapé"}
                        }
                    }
                },

                new Paciente
                {
                    Id = 2,
                    Nome = "Maria",
                    Sobrenome = " das Dores",
                    DataInicioTratamento = new DateTime(2017,2,12),
                    DataNascimento = new DateTime(1990, 1, 18),
                    Genero = PacienteGeneroEnum.Feminino,
                    TipoCobranca = PacienteTipoCobrancaEnum.PorConsulta,
                    ValorCobranca = 80.00,
                    PacienteConsultasRecorrentes = new List<PacienteConsultaRecorrente>
                    {
                        new PacienteConsultaRecorrente{
                            Id = 2,
                            PacienteId = 2,
                            Hora = new TimeSpan(08, 30, 0),
                            DiaSemana = PacienteConsultaRecorrenteDiaDaSemanaEnum.Sabado,
                            ConsultorioId = 2,
                            Consultorio = new Consultorio{Id = 2, Nome = "Mooca"},
                        },
                        new PacienteConsultaRecorrente{
                            Id = 3,
                            PacienteId = 2,
                            Hora = new TimeSpan(18, 30, 0),
                            DiaSemana = PacienteConsultaRecorrenteDiaDaSemanaEnum.QuintaFeira,
                            ConsultorioId = 2,
                            Consultorio = new Consultorio{Id = 2, Nome = "Mooca"}
                        }
                    }
                },

                new Paciente
                {
                    Id = 3,
                    Nome = "Gustavo",
                    Sobrenome = "Mendes",
                    Genero = PacienteGeneroEnum.Masculino,
                    TipoCobranca = PacienteTipoCobrancaEnum.PorConsulta,
                    ValorCobranca = 55.00
                }
            };

            _dbContext.Pacientes.AddRange(items);
            _dbContext.SaveChanges();
        }
    }
}
