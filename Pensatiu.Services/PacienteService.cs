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
        private IPacienteData _pacienteData;

        public PacienteService(IPacienteData pacienteData)
        {
            _pacienteData = pacienteData;
        }

        #region Get
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

        #endregion Get

        #region Create
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

        #endregion Create

        #region Update
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

        #endregion Update

        #region Delete
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

        #endregion Delete

        #region ConsultasRecorrentes
        public bool ConsultaRecorrenteExists(int pacienteId, int id)
        {
            return _pacienteData.ConsultaRecorrenteExists(pacienteId, id);
        }

        public PacienteConsultaRecorrenteDto ConsultaRecorrenteGetById(int pacienteId, int id)
        {
            return Mapper.Map<PacienteConsultaRecorrenteDto>(_pacienteData.ConsultaRecorrenteGetById(pacienteId, id));
        }

        public IEnumerable<PacienteConsultaRecorrenteDto> ConsultaRecorrenteGetAll(int pacienteId)
        {
            return Mapper.Map<IEnumerable<PacienteConsultaRecorrenteDto>>(_pacienteData.ConsultaRecorrenteGetAll(pacienteId));
        }
        public PacienteConsultaRecorrenteDto ConsultaRecorrenteCreate(int pacienteId, PacienteConsultaRecorrenteForCreateDto dtoForCreate)
        {
            var newRecord = _pacienteData.ConsultaRecorrenteCreate(pacienteId, Mapper.Map<PacienteConsultaRecorrente>(dtoForCreate));
            return Mapper.Map<PacienteConsultaRecorrenteDto>(newRecord);
        }
        public bool ConsultaRecorrenteUpdate(int pacienteId, int id, PacienteConsultaRecorrenteForUpdateDto dtoForUpdate)
        {
            var resourceToUpdate = Mapper.Map<PacienteConsultaRecorrente>(dtoForUpdate);
            resourceToUpdate.Id = id;
            return _pacienteData.ConsultaRecorrenteUpdate(pacienteId, resourceToUpdate);
        }
        public bool ConsultaRecorrenteDelete(int pacienteId, int id)
        {
            var resourceToDelete = Mapper.Map<PacienteConsultaRecorrente>(_pacienteData.ConsultaRecorrenteGetById(pacienteId, id));
            return _pacienteData.ConsultaRecorrenteDelete(pacienteId, resourceToDelete);
        }
        #endregion
    }
}