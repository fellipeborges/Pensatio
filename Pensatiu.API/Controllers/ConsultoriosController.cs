﻿using Microsoft.AspNetCore.Mvc;
using Pensatiu.Services;
using Pensatiu.Services.Dto.Consultorio;
using System.Net;

namespace Pensatiu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultoriosController : ControllerBase
    {
        private ConsultorioService _consultorioService;

        public ConsultoriosController(ConsultorioService consultorioService)
        {
            _consultorioService = consultorioService;
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var item = _consultorioService.Get(id);
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
            var items = _consultorioService.GetAll();
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
        public ActionResult Create([FromBody] ConsultorioForCreateUpdateDto consultorio)
        {
            if (consultorio == null)
            {
                return BadRequest();
            }
            var newConsultorio = _consultorioService.Create(consultorio);
            return CreatedAtRoute("Get", new { id = newConsultorio.Id }, newConsultorio);
        }

        [HttpPut("Update/{id}")]
        public ActionResult Update(int id, [FromBody] ConsultorioForCreateUpdateDto consultorioForCreateUpdateDto)
        {
            if (id <= 0 || consultorioForCreateUpdateDto == null)
            {
                return BadRequest();
            }
            if (_consultorioService.Exists(id) == false)
            {
                return new NotFoundResult();
            }
            var updated = _consultorioService.Update(id, consultorioForCreateUpdateDto);
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
            if (_consultorioService.Exists(id) == false)
            {
                return new NotFoundResult();
            }
            var deleted = _consultorioService.Delete(id);
            if (deleted == false)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
