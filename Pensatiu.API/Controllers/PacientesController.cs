using Microsoft.AspNetCore.Mvc;
using Pensatiu.Services;
using Pensatiu.Services.Dto.Paciente;
using Pensatiu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pensatiu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private PacienteService _pacienteService;

        public PacientesController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet("{id}", Name = "GetPaciente")]
        public ActionResult Get(int id)
        {
            var item = _pacienteService.Get(id);
            if (item == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var items = _pacienteService.GetAll();
            if (items == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(items);
            }
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] PacienteForCreateDto pacienteForCreateDto)
        {
            if (pacienteForCreateDto == null)
            {
                return BadRequest();
            }
            var newResource = _pacienteService.Create(pacienteForCreateDto);
            return CreatedAtRoute("GetPaciente", new { id = newResource.Id }, newResource);
        }

        [HttpPut("Update/{id}")]
        public ActionResult Update(int id, [FromBody] PacienteForUpdateDto pacienteForUpdateDto)
        {
            if (id <= 0 || pacienteForUpdateDto == null)
            {
                return BadRequest();
            }
            if (_pacienteService.Exists(id) == false)
            {
                return new NotFoundResult();
            }
            var updated = _pacienteService.Update(id, pacienteForUpdateDto);
            if (updated == false)
            {
                return BadRequest();
            }
            return NoContent();
        }


        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            if (_pacienteService.Exists(id) == false)
            {
                return new NotFoundResult();
            }
            var deleted = _pacienteService.Delete(id);
            if (deleted == false)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
