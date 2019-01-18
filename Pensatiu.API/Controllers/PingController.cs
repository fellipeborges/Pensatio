using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Pensatiu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : Controller
    {
        private IConfiguration _configuration;

        public PingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(DateTime.UtcNow);
        }

        [Route("config")]
        [HttpGet]
        public IActionResult Config()
        {
            var isCloudEnvironment = _configuration["IsCloudEnvironment"];
            return Ok($"isCloudEnvironment: {isCloudEnvironment}");
        }
    }
}