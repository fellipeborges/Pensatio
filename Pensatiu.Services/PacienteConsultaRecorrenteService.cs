using AutoMapper;
using Pensatiu.Entities;
using Pensatiu.Repository.Pacientes;
using Pensatiu.Services.Dto.Paciente;
using Pensatiu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensatiu.Services
{
    public class PacienteConsultaRecorrenteService : IPensatiuService<PacienteConsultaRecorrenteDto, PacienteConsultaRecorrenteForCreateDto, PacienteConsultaRecorrenteForUpdateDto>
    {
        private IPacienteConsultaRecorrenteData _pacienteConsultaRecorrenteData;

        public PacienteConsultaRecorrenteService(IPacienteConsultaRecorrenteData pacienteConsultaRecorrenteData)
        {
            _pacienteConsultaRecorrenteData = pacienteConsultaRecorrenteData;
        }

        public bool Exists(int id)
        {
            return _pacienteConsultaRecorrenteData.Exists(id);
        }

        public PacienteConsultaRecorrenteDto Get(int id)
        {
            return Mapper.Map<PacienteConsultaRecorrenteDto>(_pacienteConsultaRecorrenteData.Get(id));
        }

        public IEnumerable<PacienteConsultaRecorrenteDto> GetAll()
        {
            return null;
        }

        public IEnumerable<PacienteConsultaRecorrenteDto> GetAll(int pacienteId)
        {
            return Mapper.Map<IEnumerable<PacienteConsultaRecorrenteDto>>(_pacienteConsultaRecorrenteData.GetAll(pacienteId));
        }

        public PacienteConsultaRecorrenteDto Create(PacienteConsultaRecorrenteForCreateDto dtoForCreate)
        {
            throw new NotImplementedException();
        }

        public PacienteConsultaRecorrenteDto CreateWithParent(int pacienteId, PacienteConsultaRecorrenteForCreateDto dtoForCreate)
        {
            var newRecord = _pacienteConsultaRecorrenteData.Create(pacienteId, Mapper.Map<PacienteConsultaRecorrente>(dtoForCreate));
            return Mapper.Map<PacienteConsultaRecorrenteDto>(newRecord);
        }

        public bool Update(int id, PacienteConsultaRecorrenteForUpdateDto dtoForUpdate)
        {
            var resourceToUpdate = Mapper.Map<PacienteConsultaRecorrente>(dtoForUpdate);
            var existingItem = _pacienteConsultaRecorrenteData.Get(id);

            //Preenche as propriedades que não estão no Dto
            resourceToUpdate.Id = id;
            resourceToUpdate.PacienteId = existingItem.PacienteId;
            resourceToUpdate.ConsultorioId = existingItem.ConsultorioId;
            return _pacienteConsultaRecorrenteData.Update(resourceToUpdate);
        }

        public bool Delete(int id)
        {
            var resourceToDelete = Mapper.Map<PacienteConsultaRecorrente>(_pacienteConsultaRecorrenteData.Get(id));
            return _pacienteConsultaRecorrenteData.Delete(resourceToDelete);
        }

    }
}
