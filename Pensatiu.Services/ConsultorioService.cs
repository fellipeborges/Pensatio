using Pensatiu.Repository.Consultorios;
using Pensatiu.Entities;
using System.Collections.Generic;
using Pensatiu.Services.Dto.Consultorio;
using AutoMapper;
using System;

namespace Pensatiu.Services
{
    public class ConsultorioService
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
        #endregion

        #region Add
        public ConsultorioDto Add(ConsultorioForCreateUpdateDto consultorioDto)
        {
            CheckBeforeAdd(consultorioDto);
            var newConsultorio = _consultorioData.Add(Mapper.Map<Consultorio>(consultorioDto));
            return Mapper.Map<ConsultorioDto>(newConsultorio);
        }
        private void CheckBeforeAdd(ConsultorioForCreateUpdateDto consultorioDto)
        {
            //Verifica se já existe outro consultório com o mesmo nome
            if (_consultorioData.GetByNome(consultorioDto.Nome) != null)
            {
                throw new Exception($"Já existe um consultório com o nome '{consultorioDto.Nome}'.");
            }
        }

        #endregion

        #region Update
        public bool Update(int id, ConsultorioForCreateUpdateDto consultorioDto)
        {
            CheckBeforeUpdate(id, consultorioDto);
            var resourceToUpdate = Mapper.Map<Consultorio>(consultorioDto);
            resourceToUpdate.Id = id;
            return _consultorioData.Update(resourceToUpdate);
        }
        private void CheckBeforeUpdate(int id, ConsultorioForCreateUpdateDto consultorioDto)
        {
            //Verifica se o recurso existe
            if (_consultorioData.Exists(id) == false)
            {
                throw new Exception($"O recurso sendo alterado não existe na base.");
            }

            //Verifica se já existe outro consultório com o mesmo nome
            var con = _consultorioData.GetByNome(consultorioDto.Nome);
            if (con != null && con.Id != id)
            {
                throw new Exception($"Já existe um consultório com o nome '{consultorioDto.Nome}'.");
            }
        }
        #endregion

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
        #endregion
    }
}
