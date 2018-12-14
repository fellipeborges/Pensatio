using AutoMapper;
using Pensatiu.Entities;
using Pensatiu.Repository.Pacientes;
using Pensatiu.Services.Dto.Paciente;
using Pensatiu.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Pensatiu.Services
{
    public class PacienteService : IPensatiuService<PacienteDto, PacienteForCreateDto, PacienteForUpdateDto>
    {
        private readonly IPacienteData _pacienteData;

        public PacienteService(IPacienteData pacienteData)
        {
            _pacienteData = pacienteData;
        }

        public PacienteDto Get(int id)
        {
            return Mapper.Map<PacienteDto>(_pacienteData.Get(id));
        }

        public IEnumerable<PacienteDto> GetAll()
        {
            return Mapper.Map<IEnumerable<PacienteDto>>(_pacienteData.GetAll());
        }

        public bool Exists(int id)
        {
            return _pacienteData.Exists(id);
        }

        public PacienteDto Create(PacienteForCreateDto dtoForCreate)
        {
            CheckBeforeCreate(dtoForCreate);
            var newRecord = _pacienteData.Create(Mapper.Map<Paciente>(dtoForCreate));
            return Mapper.Map<PacienteDto>(newRecord);
        }

        private void CheckBeforeCreate(PacienteForCreateDto dtoForCreate)
        {
            //Verifica se já existe outro paciente com o mesmo nome
            if (_pacienteData.GetByNomeSobrenome(dtoForCreate.Nome, dtoForCreate.Sobrenome) != null)
            {
                throw new Exception($"Já existe um paciente com o nome completo '{dtoForCreate.Nome} {dtoForCreate.Sobrenome}'.");
            }
        }

        public bool Update(int id, PacienteForUpdateDto dtoForUpdate)
        {
            CheckBeforeUpdate(id, dtoForUpdate);
            var resourceToUpdate = Mapper.Map<Paciente>(dtoForUpdate);
            resourceToUpdate.Id = id;
            return _pacienteData.Update(resourceToUpdate);
        }

        private void CheckBeforeUpdate(int id, PacienteForUpdateDto dtoForUpdate)
        {
            //Verifica se o recurso existe
            if (_pacienteData.Exists(id) == false)
            {
                throw new Exception($"O recurso sendo alterado não existe na base.");
            }

            //Verifica se já existe outro paciente com o mesmo nome/sobrenome
            var con = _pacienteData.GetByNomeSobrenome(dtoForUpdate.Nome, dtoForUpdate.Sobrenome);
            if (con != null && con.Id != id)
            {
                throw new Exception($"Já existe um paciente com o nome completo '{dtoForUpdate.Nome} {dtoForUpdate.Sobrenome}'.");
            }
        }

        public bool Delete(int id)
        {
            CheckBeforeDelete(id);
            var resourceToDelete = Mapper.Map<Paciente>(_pacienteData.Get(id));
            return _pacienteData.Delete(resourceToDelete);
        }

        private void CheckBeforeDelete(int id)
        {
            //Verifica se o recurso existe
            if (_pacienteData.Exists(id) == false)
            {
                throw new Exception($"O recurso sendo excluído não existe na base.");
            }
        }
    }
}