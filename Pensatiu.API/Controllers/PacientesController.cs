using Microsoft.AspNetCore.Mvc;
using Pensatiu.Services;
using Pensatiu.Services.Dto.Paciente;

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

        [HttpGet("{pacienteId}/ConsultasRecorrentes/{id}", Name = "ConsultaRecorrenteGetById")]
        public ActionResult ConsultaRecorrenteGetById(int pacienteId, int id)
        {
            var item = _pacienteService.ConsultaRecorrenteGetById(pacienteId, id);
            if (item == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpGet("{pacienteId}/ConsultasRecorrentes/GetAll")]
        public ActionResult ConsultaRecorrenteGetAll(int pacienteId)
        {
            var items = _pacienteService.ConsultaRecorrenteGetAll(pacienteId);
            if (items == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(items);
            }
        }

        [HttpPost("{pacienteId}/ConsultasRecorrentes/Create")]
        public ActionResult ConsultaRecorrenteCreate(int pacienteId,
            [FromBody] PacienteConsultaRecorrenteForCreateDto pacienteConsultaRecorrenteDto)
        {
            if (pacienteId <= 0 || pacienteConsultaRecorrenteDto == null)
            {
                return BadRequest();
            }
            var newResource = _pacienteService.ConsultaRecorrenteCreate(pacienteId, pacienteConsultaRecorrenteDto);
            return CreatedAtRoute("ConsultaRecorrenteGetById", new { pacienteId, id = newResource.Id }, newResource);
        }

        [HttpPut("{pacienteId}/ConsultasRecorrentes/Update/{id}")]
        public ActionResult ConsultasRecorrentesUpdate(int pacienteId, int id,
            [FromBody] PacienteConsultaRecorrenteForUpdateDto pacienteConsultaRecorrenteForUpdate)
        {
            if (pacienteId <= 0 || id <= 0 || pacienteConsultaRecorrenteForUpdate == null)
            {
                return BadRequest();
            }
            if (_pacienteService.ConsultaRecorrenteExists(pacienteId, id) == false)
            {
                return new NotFoundResult();
            }
            var updated = _pacienteService.ConsultaRecorrenteUpdate(pacienteId, id, pacienteConsultaRecorrenteForUpdate);
            if (updated == false)
            {
                return BadRequest();
            }
            return NoContent();
        }


        [HttpDelete("{pacienteId}/ConsultasRecorrentes/Delete/{id}")]
        public ActionResult ConsultasRecorrentesDelete(int pacienteId, int id)
        {
            if (pacienteId <=0 || id <= 0)
            {
                return BadRequest();
            }
            if (_pacienteService.ConsultaRecorrenteExists(pacienteId, id) == false)
            {
                return new NotFoundResult();
            }
            var deleted = _pacienteService.ConsultaRecorrenteDelete(pacienteId, id);
            if (deleted == false)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}