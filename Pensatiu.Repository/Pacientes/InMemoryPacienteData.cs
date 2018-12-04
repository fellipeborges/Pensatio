using Pensatiu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pensatiu.Repository.Pacientes
{
    public class InMemoryPacienterioData //: IPacienteData
    {
        private List<Paciente> _items;

        public InMemoryPacienterioData()
        {
            _items = new List<Paciente>
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
        }

        public Paciente Create(Paciente item)
        {
            item.Id = _items.Max(r => r.Id) + 1;
            _items.Add(item);
            return item;
        }

        public bool Delete(Paciente item)
        {
            return _items.Remove(item);
        }

        public Paciente Get(int id)
        {
            return _items.FirstOrDefault(r => r.Id == id);
        }

        public Paciente GetByNomeSobrenome(string nome, string sobrenome)
        {
            return _items.FirstOrDefault(r => r.Nome == nome && r.Sobrenome == sobrenome);
        }

        public IEnumerable<Paciente> GetAll()
        {
            return _items.OrderBy(r => r.Nome);
        }

        public bool Update(Paciente item)
        {
            var pacienteToUpdate = _items.FirstOrDefault(i => i.Id == item.Id);
            if (pacienteToUpdate != null)
            {
                pacienteToUpdate.Nome = item.Nome;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Exists(int id)
        {
            return _items.Exists(i => i.Id == id);
        }

        public PacienteConsultaRecorrente ConsultaRecorrenteGetById(int pacienteId, int id)
        {
            var paciente = Get(pacienteId);
            return paciente.PacienteConsultasRecorrentes.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<PacienteConsultaRecorrente> ConsultaRecorrenteGetAll(int pacienteId)
        {
            var paciente = Get(pacienteId);
            return paciente.PacienteConsultasRecorrentes.OrderBy(o => o.Hora);
        }

        public PacienteConsultaRecorrente ConsultaRecorrenteCreate(int pacienteId, PacienteConsultaRecorrente item)
        {
            var max = _items.SelectMany(x => x.PacienteConsultasRecorrentes.Select(s => s.Id)).Max();
            item.Id = max + 1;
            
            item.PacienteId = pacienteId;
            item.ConsultorioId = item.ConsultorioId;
            item.Consultorio = new Consultorio
            {
                Id = item.ConsultorioId,
                Nome = $"Mocked {item.ConsultorioId}"
            };

            var pacienteToUpdate = _items.FirstOrDefault(p => p.Id == pacienteId);
            pacienteToUpdate.PacienteConsultasRecorrentes.Add(item);

            return item;
        }

        public bool ConsultaRecorrenteUpdate(int pacienteId, PacienteConsultaRecorrente item)
        {
            var pacienteToUpdate = _items.FirstOrDefault(i => i.Id == pacienteId);
            var consultaRecorrenteToUpdate = pacienteToUpdate.PacienteConsultasRecorrentes.FirstOrDefault(i => i.Id == item.Id);
            if (consultaRecorrenteToUpdate != null)
            {
                consultaRecorrenteToUpdate.DiaSemana = item.DiaSemana;
                consultaRecorrenteToUpdate.ConsultorioId = item.ConsultorioId;
                consultaRecorrenteToUpdate.Consultorio = new Consultorio
                {
                    Id = item.ConsultorioId,
                    Nome = $"Mocked {item.ConsultorioId}"
                };
                consultaRecorrenteToUpdate.Hora = item.Hora;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ConsultaRecorrenteDelete(int pacienteId, PacienteConsultaRecorrente item)
        {
            var paciente = Get(pacienteId);
            return paciente.PacienteConsultasRecorrentes.Remove(item);
        }

        public bool ConsultaRecorrenteExists(int pacienteId, int id)
        {
            var consultaRecorrente = ConsultaRecorrenteGetById(pacienteId, id);
            if (consultaRecorrente == null)
            {
                return false;
            }
            return true;
        }
    }
}