using Pensatiu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Repository.Context
{
    public class SeedDataLoader: IDisposable
    {
        private PensatiuDbContext _dbContext;

        public SeedDataLoader(PensatiuDbContext pensatiuDbContext)
        {
            _dbContext = pensatiuDbContext;
        }

        public void Dispose()
        {}

        public void Load()
        {
            LoadConsultorios();
            LoadPacientes();
        }

        private void LoadConsultorios()
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

        private void LoadPacientes()
        {
            var items = new List<Paciente>
            {
                new Paciente
                {
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
                            PacienteId = 2,
                            Hora = new TimeSpan(08, 30, 0),
                            DiaSemana = PacienteConsultaRecorrenteDiaDaSemanaEnum.Sabado,
                            ConsultorioId = 2,
                            Consultorio = new Consultorio{Id = 2, Nome = "Mooca"},
                        },
                        new PacienteConsultaRecorrente{
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
