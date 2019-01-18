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
    public class StatusController : Controller
    {
        private IConfiguration _configuration;

        public StatusController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ret = new {
                Datetime = DateTime.UtcNow,
                Environment_CurrentDirectory = Environment.CurrentDirectory,
                Environment_MachineName = Environment.MachineName,
                Environment_Is64BitOperatingSystem = Environment.Is64BitOperatingSystem,
                Environment_ProcessorCount = Environment.ProcessorCount,
                Environment_Version = $"{Environment.Version.Major}.{Environment.Version.Minor}.{Environment.Version.Build}.{Environment.Version.Revision}"
            };
            return Ok(ret);
        }
    }
}