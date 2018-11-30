using AutoMapper;
using Pensatiu.Entities;
using Pensatiu.Repository.Consultorios;
using Pensatiu.Services.Dto.Consultorio;
using Pensatiu.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Pensatiu.Services
{
    public class ConsultorioService : IPensatiuService<ConsultorioDto, ConsultorioForCreateDto, ConsultorioForUpdateDto>
    {
        private IConsultorioData _consultorioData;

        public ConsultorioService(IConsultorioData consultorioData)
        {
            _consultorioData = consultorioData;
        }

        #region Get

        public ConsultorioDto Get(int id)
        {
            return Mapper.Map<ConsultorioDto>(_consultorioData.Get(id));
        }

        public IEnumerable<ConsultorioDto> GetAll()
        {
            return Mapper.Map<IEnumerable<ConsultorioDto>>(_consultorioData.GetAll());
        }

        public bool Exists(int id)
        {
            return _consultorioData.Exists(id);
        }

        #endregion Get

        #region Create

        public ConsultorioDto Create(ConsultorioForCreateDto consultorioForCreateDto)
        {
            CheckBeforeAdd(consultorioForCreateDto);
            var newResource = _consultorioData.Create(Mapper.Map<Consultorio>(consultorioForCreateDto));
            return Mapper.Map<ConsultorioDto>(newResource);
        }

        private void CheckBeforeAdd(ConsultorioForCreateDto consultorioForCreateDto)
        {
            //Verifica se já existe outro consultório com o mesmo nome
            if (_consultorioData.GetByNome(consultorioForCreateDto.Nome) != null)
            {
                throw new Exception($"Já existe um consultório com o nome '{consultorioForCreateDto.Nome}'.");
            }
        }

        #endregion Create

        #region Update

        public bool Update(int id, ConsultorioForUpdateDto consultorioForUpdateDto)
        {
            CheckBeforeUpdate(id, consultorioForUpdateDto);
            var resourceToUpdate = Mapper.Map<Consultorio>(consultorioForUpdateDto);
            resourceToUpdate.Id = id;
            return _consultorioData.Update(resourceToUpdate);
        }

        private void CheckBeforeUpdate(int id, ConsultorioForUpdateDto consultorioForUpdateDto)
        {
            //Verifica se o recurso existe
            if (_consultorioData.Exists(id) == false)
            {
                throw new Exception($"O recurso sendo alterado não existe na base.");
            }

            //Verifica se já existe outro consultório com o mesmo nome
            var con = _consultorioData.GetByNome(consultorioForUpdateDto.Nome);
            if (con != null && con.Id != id)
            {
                throw new Exception($"Já existe um consultório com o nome '{consultorioForUpdateDto.Nome}'.");
            }
        }

        #endregion Update

        #region Delete

        public bool Delete(int id)
        {
            CheckBeforeDelete(id);
            var resourceToDelete = Mapper.Map<Consultorio>(_consultorioData.Get(id));
            return _consultorioData.Delete(resourceToDelete);
        }

        private void CheckBeforeDelete(int id)
        {
            //Verifica se o recurso existe
            if (_consultorioData.Exists(id) == false)
            {
                throw new Exception($"O recurso sendo excluído não existe na base.");
            }
        }

        #endregion Delete
    }
}